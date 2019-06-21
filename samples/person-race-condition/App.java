import java.util.concurrent.Semaphore;

class App
{
    private static MutableString name;

    private static boolean stop = false;

    public static void main(String[] args) throws Exception
    {
        Person person = createPersonWithEmptyName();

        System.out.println(String.format("Person's name is \"%s\"", person.getName()));
    }

    private static Person createPersonWithEmptyName() throws Exception
    {
        Semaphore semaphore = new Semaphore(0);
        Person person;

        Thread thread = new Thread( () -> {
            try
            {
                while ( !stop )
                {
                    semaphore.acquire();
                    name.clear();
                }
            }
            catch ( InterruptedException e ) { }
        } );
        thread.start();

        int tries = 0;
        while ( true )
        {
            tries++;

            name = new MutableString("Mallory");
            semaphore.release();

            try
            {
                person = new Person(name);

                if ( person.getName().length() == 0 )
                {
                    stop = true;
                    semaphore.release();
                    thread.join();
                    System.out.println(String.format("Managed to do it in %d tries", tries));
                    return person;
                }
            }
            catch (Exception e) { }
        }
    }
}