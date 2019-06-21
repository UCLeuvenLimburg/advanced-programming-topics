class Person
{
    private MutableString name;

    public Person(MutableString name)
    {
        setName(name);
    }

    public MutableString getName()
    {
        return this.name.copy();
    }

    public void setName(MutableString name)
    {
        if ( name == null || name.length() == 0 )
        {
            throw new IllegalArgumentException();
        }
        else
        {
            this.name = name.copy();
        }
    }
}