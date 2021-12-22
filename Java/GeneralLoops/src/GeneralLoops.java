import java.util.List;

/**
 * Interfejs ogĂłlnego systemu pozwalajÄcego wyznaczaÄ stany licznikĂłw
 * zagnieĹźdĹźonych pÄtli typu for.
 */
public interface GeneralLoops {
	/**
	 * Metoda ustalajÄca dolne limity pÄtli. Metoda wywoĹywana opcjonalnie. JeĹli
	 * metody nie wywoĹano pÄtle rozpoczynajÄ iteracje od 0. Limit na pozycji 0
	 * odpowiada pÄtli zewnÄtrznej. Ostatni - najbardziej zagnieĹźdzonej pÄtli
	 * wewnÄtrznej.
	 * 
	 * @param limits lista wartoĹci, od ktĂłrych rozpoczynane sÄ iteracje w kolejnych
	 *               pÄtlach.
	 */
	public void setLowerLimits(List<Integer> limits);

	/**
	 * Metoda ustalajÄca gĂłrny limit pÄtli. Metoda wywoĹywana opcjonalnie. JeĹli
	 * metody nie wywoĹano gĂłrnym limitem pÄtli jest 0. Limit na pozycji 0
	 * odpowiada pÄtli zewnÄtrznej. Ostatni - najbardziej zagnieĹźdzonej pÄtli
	 * wewnÄtrznej.
	 * 
	 * @param limits lista wartoĹci, na ktĂłrych koĹczy siÄ wykonywanie iteracji w
	 *               kolejnych pÄtlach.
	 */
	public void setUpperLimits(List<Integer> limits);

	/**
	 * Metoda zwraca listÄ list stanĂłw pÄtli - zewnÄtrzna lista to kolejne iteracje,
	 * wewnÄtrzna stan licznikĂłw w danej iteracji. Np. przy limitach wynoszÄcych
	 * {0,0,1} i {1,2,2} wynikiem powinno byÄ:
	 * 
	 * <pre>
	 * {0,0,1},
	 * {0,0,2},
	 * {0,1,1},
	 * {0,1,2},
	 * {0,2,1},
	 * {0,2,2},
	 * {1,0,1},
	 * {1,0,2},
	 * {1,1,1},
	 * {1,1,2},
	 * {1,2,1},
	 * {1,2,2}
	 * </pre>
	 * 
	 * czyli 12 (2x3x2) list o rozmiarze 3. KolejnoĹÄ danych ma znaczenie i
	 * odpowiada dziaĹaniu zagnieĹźdĹźonych pÄtli for.
	 * 
	 * @return lista zawierajÄca listy stanĂłw licznikĂłw poszczegĂłlnych pÄtli.
	 */
	public List<List<Integer>> getResult();
}