class UsersManegment
{
    public Dictionary<string, string> Users = new Dictionary<string, string>();
    
    public void Add_logpass (string Login, string pass)
    {
        Users.Add(Login, pass);
    }
    public void DeleteLoginUser(string Login)
    {
        Users.Remove(Login);
    }
    public void ChangeInfo(string Login, string newLogin, string newPass)
    {
        Users.Remove(Login);
        Users.Add(newLogin, newPass);
    }
    public string GetPassbyLogin(string Login)
    {
        return Users[Login];
    }
    public void PrintAllUsers()
    {
        Console.WriteLine("List of users:");
        foreach (var user in Users)
        {
            Console.WriteLine($"Login: {user.Key}, Password: {user.Value}");
        }
    }
}

class Cafe
{
    public Dictionary<string, bool> Visitors = new Dictionary<string, bool>();
    public Queue<string> VisitorQueue = new Queue<string>();

    public int FreeTable = 2;

    public void AddVisitor(string Visitor, bool WasReserved)
    {
        if (WasReserved)
        {
            Visitors.Add(Visitor, WasReserved);
        }
        else
        {
            if (FreeTable!=0)
            {
                Visitors.Add(Visitor, WasReserved);
                FreeTable--;
            }
            else
            {
                VisitorQueue.Enqueue(Visitor);
            }
        }
    }
    public void RemoveVisitor(string Visitor)
    {
        if (VisitorQueue.Count()!=0 && Visitors[Visitor])
        {
            Visitors.Remove(Visitor);
        }
        else if (VisitorQueue.Count() != 0)
        {
            Visitors.Remove(Visitor);
            string NextVisitor = VisitorQueue.Dequeue();
            Visitors.Add(NextVisitor, false);
        }
        else
        {
            Visitors.Remove(Visitor);
            FreeTable++;
        }
    }
    public void ShowCafeStatus()
    {
        Console.WriteLine("\n=== Стан кафе ===");
        Console.WriteLine($"Вільних столиків: {FreeTable}");
        Console.WriteLine("Відвідувачі у кафе:");
        foreach (var visitor in Visitors)
        {
            Console.WriteLine($"- {visitor.Key}");
        }
        Console.WriteLine("Queue:");
        foreach (var visitor in VisitorQueue)
        {
            Console.WriteLine($"- {visitor}");
        }
    }
}

class Program
{
    static void Main()
    {
        ////task 1
        //UsersManegment userManager = new UsersManegment();

        //userManager.Add_logpass("user1", "pass1");
        //userManager.Add_logpass("user2", "pass2");

        //userManager.PrintAllUsers();

        //userManager.ChangeInfo("user1", "user1_new", "newPass1");

        //userManager.DeleteLoginUser("user2");

        //Console.WriteLine($"Password for user1_new: {userManager.GetPassbyLogin("user1_new")}");

        //userManager.PrintAllUsers();
        //task 3
        Cafe cafe = new Cafe();

        cafe.AddVisitor("Alice", false);
        cafe.AddVisitor("Bob", false);
        cafe.AddVisitor("Charlie", true);
        cafe.AddVisitor("Diana", false);
        cafe.AddVisitor("Eve", false);

        cafe.ShowCafeStatus();

        cafe.RemoveVisitor("Alice");
        cafe.RemoveVisitor("Charlie");

        cafe.ShowCafeStatus();

        cafe.RemoveVisitor("Diana");
        cafe.RemoveVisitor("Bob");
        cafe.ShowCafeStatus();
    }
}
