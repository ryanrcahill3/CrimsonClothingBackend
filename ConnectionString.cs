namespace api
{
    public class ConnectionString
    {
        public string cs { get; set; }

        public ConnectionString()
        {
            string server = "r4wkv4apxn9btls2.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "zevo5s1w2h1kbehw";
            string port = "3306";
            string userName = "r6k1rdjpcm90oj6e";
            string password = "h4u0um0q9wap5b45";



            cs = $@"server = {server};user={userName};database={database};port={port};password={password};Convert Zero DateTime=True;";
        }
    }
}