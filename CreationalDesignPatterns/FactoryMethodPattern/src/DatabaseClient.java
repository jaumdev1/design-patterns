
interface DatabaseConnection {
    void connect();
    void query(String sql);
}


class MySqlConnection implements DatabaseConnection {
    @Override
    public void connect() {
        System.out.println("Conectado ao MySQL Database");
    }

    @Override
    public void query(String sql) {
        System.out.println("Executando query no MySQL: " + sql);
    }
}

class PostgreSqlConnection implements DatabaseConnection {
    @Override
    public void connect() {
        System.out.println("Conectado ao PostgreSQL Database");
    }

    @Override
    public void query(String sql) {
        System.out.println("Executando query no PostgreSQL: " + sql);
    }
}

interface DatabaseConnectionFactory {
    DatabaseConnection createConnection();
}


class MySqlConnectionFactory implements DatabaseConnectionFactory {
    @Override
    public DatabaseConnection createConnection() {
        return new MySqlConnection();
    }
}

class PostgreSqlConnectionFactory implements DatabaseConnectionFactory {
    @Override
    public DatabaseConnection createConnection() {
        return new PostgreSqlConnection();
    }
}


public class DatabaseClient {
    public static void main(String[] args) {

        DatabaseConnectionFactory mySqlConnectionFactory = new MySqlConnectionFactory();
        DatabaseConnectionFactory postgreSqlConnectionFactory = new PostgreSqlConnectionFactory();


        DatabaseConnection mySqlConnection = mySqlConnectionFactory.createConnection();
        DatabaseConnection postgreSqlConnection = postgreSqlConnectionFactory.createConnection();


        mySqlConnection.connect();
        mySqlConnection.query("SELECT * FROM users");

        postgreSqlConnection.connect();
        postgreSqlConnection.query("SELECT * FROM employee");
    }
}
