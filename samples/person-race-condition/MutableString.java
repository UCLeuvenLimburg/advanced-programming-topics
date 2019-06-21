class MutableString
{
    private String value;

    public MutableString(String value)
    {
        this.value = value;
    }

    public int length()
    {
        return value.length();
    }

    public void set(String value)
    {
        this.value = value;
    }

    public void clear()
    {
        this.value = "";
    }

    public MutableString copy()
    {
        return new MutableString(value);
    }

    @Override
    public String toString()
    {
        return value;
    }
}
