import java.util.Map;

/**
 * Interfejs sklepu. Wszyskie metody mogÄ byÄ wywoĹywane wspĂłĹbieĹźnie. Metoda
 * purchase jako jedyna moĹźe doprowadziÄ to zablokowania pracy wywoĹujÄcego jÄ
 * wÄtku (stan wÄtku WAITING). PozostaĹe metody muszÄ daÄ siÄ wywoĹaÄ pomimo
 * istniejÄcych zablokowanych wÄtkĂłw oczekujÄcych na zakoĹczenie metody
 * purchase.
 */
public interface ShopInterface {
	/**
	 * Dostawa dĂłbr do sklepu. Dostawa opisana jest w postaci mapy. Kluczem jest
	 * nazwa dostarczonego produktu, wartoĹciÄ iloĹÄ dostarczonych sztuk. Efektem
	 * ubocznym metody jest zakoĹczenie oczekiwania wszystkich tych wÄtkĂłw, ktĂłre
	 * wywoĹaĹy metodÄ purchase dla towaru, ktĂłrego nie byĹo w sklepie w
	 * wystarczajÄcej iloĹci, a zostaĹ on dostarczony. Dostawa nie koĹczy
	 * oczekiwania wÄtkĂłw, ktĂłre oczekujÄ na dostawÄ innego towaru.
	 * 
	 * @param goods spis dostarczonych do sklepu dĂłbr. Klucz nazwa towaru, wartoĹÄ
	 *              iloĹÄ dostarczonych sztuk.
	 */
	public void delivery(Map<String, Integer> goods);

	/**
	 * Zakup towaru o podanej nazwie (productName) w liczbie quantity sztuk. W
	 * przypadku braku takiego towaru lub braku odpowiedniej iloĹci sztuk towaru
	 * wÄtek, ktĂłry wywoĹaĹ metodÄ jest blokowany do czasu dostawy zawierajÄcej ten
	 * produkt. JeĹli sklep posiada na stanie odpowiedniÄ iloĹÄ sztuk towaru zakup
	 * jest realizowany powodujÄc odpowiednie zmniejszenie stanu magazynu.
	 * 
	 * @param productName nazwa towaru
	 * @param quantity    iloĹÄ sztuk
	 * @return true - zakup zrealizowany, false - zakup niezrealizowany.
	 */
	public boolean purchase(String productName, int quantity);

	/**
	 * Aktualny stan magazynu. Mapa zawiera informacje o wszystkich towarach, ktĂłre
	 * zostaĹy dostarczone do sklepu, nawet jeĹli w magazynie nie ma ani jednej
	 * sztuki danego towaru (wszystkie zostaĹy sprzedane). Kluczem jest nazwa
	 * towaru, wartoĹciÄ aktualna liczba szuk towaru w magazynie sklepu.
	 * 
	 * @return stan magazynu sklepu
	 */
	public Map<String, Integer> stock();
}