package compression;

import java.util.Map;

public interface CompressionInterface {
	/**
	 * Metoda dodaje pojedyncze sĹowo. Wszystkie sĹowa bÄdÄ mieÄ takÄ samÄ dĹugoĹÄ i
	 * skĹadaÄ siÄ wyĹÄcznie z kombinacji zer i jedynek.
	 * 
	 * @param word sĹowo z ciÄgu danych przeznaczonych do kompresji.
	 */
	public void addWord(String word);

	/**
	 * Metoda zleca wykonanie kompresji przekazanych danych.
	 */
	public void compress();

	/**
	 * Metoda zwraca nagĹĂłwek. Mapa zawiera jako klucz ciÄg, ktĂłry koduje sĹowo i
	 * sĹowo, ktĂłre jest nim kodowane. W nagĹĂłwku umieszczane sÄ wyĹÄcznie
	 * informacje o sĹowach, ktĂłre kodowane bÄdÄ za pomocÄ mniejszej niĹź oryginalna
	 * iloĹci bitĂłw. JeĹli przekazanej sekwencji nie moĹźna skompresowaÄ podanÄ
	 * metodÄ metoda zwraca mapÄ o rozmiarze 0.
	 * 
	 * @return mapa kodowania sĹĂłw
	 */
	public Map<String, String> getHeader();

	/**
	 * Metoda zwraca kolejne elementy skompresowanej sekwencji.
	 * 
	 * @return pojedyncze sĹowo ze skompresowanej sekwencji.
	 */
	public String getWord();
}
