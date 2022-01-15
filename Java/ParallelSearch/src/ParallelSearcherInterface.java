
/**
 * Interfejs wspĂłĹbieĹźnego systemu przeszukiwania skrytek.
 */
public interface ParallelSearcherInterface {
	/**
	 * Metoda ustawiajÄca dostÄp do obiektu dostarczajÄcego obiekty zawierajÄce
	 * skrytki.
	 * 
	 * @param supplier obiekt dostarczajÄcy obiekty zawierajÄce skrytki
	 */
	public void set(HidingPlaceSupplierSupplier supplier);
}