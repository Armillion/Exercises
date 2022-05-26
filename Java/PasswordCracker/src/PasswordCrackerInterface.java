import java.io.IOException;
import java.net.UnknownHostException;

public interface PasswordCrackerInterface {
	/**
	 * Metoda zwraca hasĹo do serwisu znajdujÄcego siÄ na komputerze host i
	 * oczekujÄcego na poĹÄczenia na porcie o numerze port.
	 * 
	 * @param host adres serwera
	 * @param port numer portu
	 * @return hasĹo
	 * @throws IOException 
	 * @throws UnknownHostException 
	 */
	public String getPassword(String host, int port) throws UnknownHostException, IOException;
}