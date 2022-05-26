import java.util.List;
import java.util.function.Supplier;

/**
 * Interfejs kasjera rozliczajÄcego zakupy.
 */
public interface KasjerInterface {
	/**
	 * Rozliczenia zakupĂłw polega na pobraniu z przekazanych pieniÄdzy ceny i
	 * zwrĂłceniu reszty. WyliczajÄc resztÄ naleĹźy uwzglÄdniÄ prawa matematyki,
	 * nierozmienialnych zĹotĂłwek oraz chÄÄ minimalizacji traconych ĹrodkĂłw (kasjer
	 * zwraca nierozmienialne zĹotĂłwki tylko jeĹli musi).
	 * 
	 * @param cena      kwota do zapĹaty za towar
	 * @param pieniadze przekazane kasjerowi pieniÄdze
	 * @return reszta
	 */
	public List<Pieniadz> rozlicz(int cena, List<Pieniadz> pieniadze);

	/**
	 * Metoda zwraca aktualny stan kasy.
	 * 
	 * @return stan kasy czyli lista posiadanych pieniedzy.
	 */
	public List<Pieniadz> stanKasy();

	/**
	 * Metoda pozwala na przekazanie dostepu do serwisu, ktĂłry pozwoli na
	 * rozmienienie pieniedzy.
	 * 
	 * @param rozmieniacz serwis rozmieniajacy pieniadze
	 */
	public void dostępDoRozmieniacza(RozmieniaczInterface rozmieniacz);

	/**
	 * Metoda ustawia dostep do dostawcy poczatkowego stanu kasy. Przekazanego
	 * dostawce naleĹźy odpytaÄ o pieniÄdze w kasie i ponawiaÄ pytanie aĹź do
	 * uzyskania null.
	 * 
	 * @param dostawca dostarcza poczatkowego stanu pieniedzy w kasie
	 */
	public void dostępDoPoczątkowegoStanuKasy(Supplier<Pieniadz> dostawca);
}