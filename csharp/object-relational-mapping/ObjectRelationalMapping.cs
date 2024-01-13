using System;

public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        if(database.DbState != Database.State.Closed)
        {
            throw new InvalidOperationException("Database is already open");
        }
        database.BeginTransaction();
    }

    public void Write(string data)
    {
        if(database.DbState != Database.State.TransactionStarted)
        {
            database.Dispose();
            return;
        }
        database.lastData = data;
        try
        {
            database.Write(data);
        }
        catch(InvalidOperationException)
        {
            database.Dispose();
        }

    }

    public void Commit()
    {
        if(database.DbState != Database.State.DataWritten)
        {
            database.Dispose();
        }
        database.Dispose();
    }

    public void Dispose()
    {
        database.Dispose();
    }
}
