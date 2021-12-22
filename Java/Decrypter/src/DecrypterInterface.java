import java.util.Map;

/**
 * Interfejs systemu dekodujÄcego zaszyfrowane wiadomoĹci.
 */
public interface DecrypterInterface {
	/**
	 * Metoda do przekazania tekstu zakodowanej wiadomoĹci.
	 * 
	 * @param encryptedDocument zaszyfrowana wiadomoĹÄ.
	 */
	public void setInputText(String encryptedDocument);

	/**
	 * Metoda zwraca mapÄ ujawniajÄcÄ sposĂłb kodowania. Kluczem tej mapy jest
	 * kodowany znak. WartoĹciÄ znak, na ktĂłry klucz zostaĹ zamieniony w
	 * zaszyfrowanej wiadomoĹci.
	 * 
	 * @return SposĂłb zakodowania wiadomoĹci czyli mapa prowadzÄca od znaku do jego
	 *         kodu. W przypadku braku moĹźliwoĹci rozkodowania wiadomoĹci lub jej
	 *         braku (do setInputText przekazano null, lub metody nie wywoĹano)
	 *         zwracana jest mapa o rozmiarze 0.
	 */
	public Map<Character, Character> getCode();

	/**
	 * Metoda zwraca mapÄ ujawniajÄcÄ sposĂłb moĹźliwiajÄcy zdekowanie
	 * zaszyfrowanej wiadomoĹci Kluczem tej mapy jest kod. WartoĹciÄ znak, na ktĂłry
	 * klucz naleĹźy zamieniÄ aby odtworzyÄ oryginalnÄ wiadomoĹÄ.
	 * 
	 * @return SposĂłb zdekodowania wiadomoĹci czyli mapa prowadzÄca od kodu do
	 *         oryginalnego znaku. W przypadku braku moĹźliwoĹci rozkodowania
	 *         wiadomoĹci lub jej braku (do setInputText przekazano null, lub metody
	 *         nie wywoĹano) zwracana jest mapa o rozmiarze 0.
	 */
	public Map<Character, Character> getDecode();
}