
public class User
{
    public string email;
    public string displayName;
    public float point = 0;
    public float time = 0;

    public User()
    {
    }

    public User(string email, string displayName)
    {
        this.email = email;
        this.displayName = displayName;
    }
}