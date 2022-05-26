import java.sql.Connection;
import java.util.Optional;

public interface PrzechowywaczI {

	/**
	 * Metoda ustawia poĹÄczenie do bazy danych typu SQLite.
	 * 
	 * @param connection referencja do utworzonego poĹÄczenia do bazy danych.
	 */
	public void setConnection(Connection connection);

	/**
	 * Zleca pisanie obiektu na dysku w podanym katalogu.
	 * 
	 * @param path           Identyfikator katalogu, w ktĂłrym ma zostaÄ zapisany
	 *                       obiekt.
	 * @param obiektDoZapisu Referencja do obiektu, ktory ma zostac zapisany na
	 *                       dysku.
	 * @return Identyfikator obiektu. Podanie tego identyfikatora w metodzie read ma
	 *         pozwolic na odzyskanie obiektu.
	 * @throws IllegalArgumentException bĹÄdny identyfikator ĹcieĹźki (brak takiej w
	 *                                  bazie) lub problem z przekazanÄ referencjÄ
	 *                                  obiektDoZapisu.
	 */
	public int save(int path, Object obiektDoZapisu) throws IllegalArgumentException;

	/**
	 * Zleca odczyt obiektu o podanym id.
	 * 
	 * @param obiektDoOdczytu Identyfikator obiektu, ktory chcemy odzyskac.
	 * @return Obiekt typu Optional zawierajÄcy (o ile istnieje) obiekt o podanym
	 *         obiektDoOdczytu. W przypadku podania bĹÄdnego idektyfikatora
	 *         obiektDoOdczytu metoda zwraca pusty obiekt Optional. Metoda
	 *         <b>nigdy</b> nie zwraca null.
	 */
	public Optional<Object> read(int obiektDoOdczytu);
}