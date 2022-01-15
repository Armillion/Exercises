/**
 * Dostawca skrytek
 *
 */
public interface HidingPlaceSupplier {
	/**
	 * Interfejs pojedynczej skrytki
	 *
	 */
	public interface HidingPlace {
		/**
		 * Zwraca true jeĹli skrytka coĹ zawiera. W przeciwnym wypadku false.
		 * 
		 * @return czy skrytka posiada zawartoĹÄ
		 */
		public boolean isPresent();

		/**
		 * Otwiera skrytkÄ i zwraca jej wartoĹÄ.
		 * 
		 * @return wartoĹÄ zawartoĹci skrytki
		 */
		public double openAndGetValue();
	}

	/**
	 * Zwraca pojedynczÄ skrytkÄ, brak skrytek sygnalizuje za pomocÄ null. Metoda
	 * moĹźe byÄ wykonywana wspĂłĹbieĹźnie.
	 * 
	 * @return obiekt skrytki
	 */
	public HidingPlace get();

	/**
	 * Liczba wÄtkĂłw, ktĂłre majÄ obsĹugiwaÄ przeszukiwanie skrytek.
	 * WartoĹÄ jest staĹa dla danego obiektu.
	 * 
	 * @return liczba wÄtkĂłw jakie majÄ przeszukiwaÄ skrytki
	 */
	public int threads();
}