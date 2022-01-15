
/**
 * Interfejs dostawcy obiektĂłw zgodnych z HidingPlaceSupplier
 */
public interface HidingPlaceSupplierSupplier {
	/**
	 * Metoda zwraca obiekty dostarczajÄce skrytek aĹź do wyczerpania ich liczby.
	 * Brak kolejnych obiektĂłw sygnalizowane jest poprzez zwrĂłcenie null.
	 * 
	 * @param totalValueOfPreviousObject suma wartoĹci przedmiotĂłw w wyciÄgniÄtych
	 *                                   ze skrytek dostrczonych przez poprzedni
	 *                                   obiekt HidingPlaceSupplier.
	 * @return obiekt dostarcy skrytek
	 */
	public HidingPlaceSupplier get(double totalValueOfPreviousObject);
}