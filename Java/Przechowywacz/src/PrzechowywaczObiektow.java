import java.io.*;
import java.sql.*;
import java.util.Optional;

public class PrzechowywaczObiektow implements PrzechowywaczI {

	private Connection connect;
	
	@Override
	public void setConnection(Connection connection) {
		// TODO Auto-generated method stub
		connect = connection;
	}

	@Override
	public int save(int path, Object obiektDoZapisu) throws IllegalArgumentException {
		// TODO Auto-generated method stub
		Statement stat;
		Integer id = 1;
		String name = "Plik_";
		try {
			stat = connect.createStatement();
			ResultSet rs = stat.executeQuery("SELECT * FROM pliki");
			while(rs.next())
			{
				id++;
			}
			name += String.valueOf(id);
			
			String pathname = "";
			rs = stat.executeQuery("SELECT * FROM katalogi");
			while(rs.next())
			{
				if(rs.getInt(1) == path)
				{
					pathname = rs.getString(2);
					break;
				}
			}
			
			if(pathname.equals(""))
			{
				throw new IllegalArgumentException();
			}
			
			PreparedStatement ps = connect.prepareStatement("INSERT INTO Pliki VALUES ( ? , ? , ? )");
            ps.setInt(1, id);
            ps.setInt(2, path);
            ps.setString(3, name);
            ps.executeUpdate();
			
			
			FileOutputStream output = new FileOutputStream(pathname + File.separator + name);
			ObjectOutputStream out = new ObjectOutputStream(output);
			out.writeObject(obiektDoZapisu);
			out.close();
			output.close();
			
			return id;
			
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return 0;
	}

	@Override
	public Optional<Object> read(int obiektDoOdczytu) {
		// TODO Auto-generated method stub
		int i = -1;	
		String filename = "";
		String cataloguename = "";
		Statement stat;
		try {
			stat = connect.createStatement();
			ResultSet rs = stat.executeQuery("SELECT * FROM pliki");
			while(rs.next())
			{
				if(rs.getInt(1) == obiektDoOdczytu)
				{
					i = rs.getInt(2);
					filename = rs.getString(3);
					break;
				}
			}
			
			if(i == -1)
			{
				return Optional.empty();
			}
			
			rs = stat.executeQuery("SELECT * FROM katalogi");
			while(rs.next())
			{
				if(rs.getInt(1) == i)
				{
					cataloguename = rs.getString(2);
					break;
				}
			}
			
			FileInputStream output = new FileInputStream(cataloguename + File.separator + filename);
			ObjectInputStream out = new ObjectInputStream(output);
			Optional<Object> a = Optional.ofNullable(out.readObject());
			out.close();
			output.close();
			
			return a;
			
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return Optional.empty();
	}

}
