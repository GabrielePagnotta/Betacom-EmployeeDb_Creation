namespace EmployeeDb
{
    public static class ErrorLog
    {
        public static void IdPUTError(Exception ex)
        {
            using (StreamWriter write = new StreamWriter("C:\\Users\\gabri\\OneDrive\\Desktop\\Esercizi Betacom\\EmployeeDb\\ErrorLog\\Errors.txt", true))
            {
                write.WriteLine("Date:");
                DateTime data = DateTime.Now;
                write.WriteLine(data.ToString());
                write.WriteLine("Error:");
                write.WriteLine(ex.ToString());
                write.WriteLine("Avvenuto in:");
                write.WriteLine("Task<IActionResult> PutEmployee(string id, Employee employee)");
                write.WriteLine(new string('-', 100));
            }
        }
    }
}
