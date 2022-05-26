import java.util.List;

/**
 * Interfejs serwisu rozmieniajacego pieniadze.
 */
@FunctionalInterface
public interface RozmieniaczInterface {
	/**
	 * Metoda rozmienia (o ile jest to mozliwe) pieniadze na drobniejsze.
	 * RozmieniaÄ moĹźna wyĹÄcznie pieniÄdze rozmienialne.
	 * W wyniku uzyskuje siÄ pieniÄdze rozmienialne.
	 * Suma nominaĹĂłw zwrĂłconych pieniÄdzy zgadza siÄ z nominaĹem
	 * pieniÄdza przekazanego. Rozmiana moĹźe byÄ wykonana dowolnie.
	 * Np.
	 * <pre>
	 * 100 -> 50 + 50
	 * 100 -> 20 + 10 + 10 + 10 + 50
	 * </pre>
	 * NajniĹźszy nominaĹ, ktĂłry podlega rozmianie to 2 zĹ.
	 * 
	 * @param pieniadzDoRozmienienia pieniadz rozmieniany
	 * @return uzyskane drobne
	 */
	public List<Pieniadz> rozmien( Pieniadz pieniadzDoRozmienienia );
}