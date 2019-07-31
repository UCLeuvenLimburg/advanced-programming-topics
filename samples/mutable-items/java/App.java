import java.util.HashSet;

public class App
{
    public static void main(String[] args)
    {
        var set = new HashSet<Item>();
        var i1 = new Item(1);
        var i2 = new Item(2);
        var i3 = new Item(3);
        var i4 = new Item(4);
        set.add(i1);
        set.add(i2);
        set.add(i3);
        set.add(i4);

        i3.hc = 0;

        System.out.println(set.contains(i1));
        System.out.println(set.contains(i2));
        System.out.println(set.contains(i3));
        System.out.println(set.contains(i4));
    }

    private static class Item
    {
        public int hc;

        public Item(int hc)
        {
            this.hc = hc;
        }

        @Override
        public int hashCode()
        {
            return hc;
        }

        @Override
        public boolean equals(Object o)
        {
            if ( o instanceof Item )
            {
                var other = (Item) o;

                return this.hc == other.hc;
            }
            else
            {
                return false;
            }
        }
    }
}