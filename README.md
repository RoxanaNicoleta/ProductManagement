# ProductManagement

	Proiectul ProductManagementApp este o aplicatie desktop realizata in C# si WinForms care gestioneaza o lista de produse, folosind design patterns precum Factory si Observer.
	Aplicatia permite utilizatorilor sa adauge, sa actualizeze si sa elimine produse de tip electronic si alimentar, folosind factory specializate (ElectronicProductFactory si FoodProductFactory) pentru crearea produselor.
	Lista de produse este gestionata intr-un mod care permite separarea logicii de manipulare a produselor de interfata cu utilizatorul. Folosind pattern-ul Observer, interfata utilizatorului este actualizata automat atunci cand produsele sunt adaugate, sterse sau actualizate. Acest sistem notifică automat componentele UI despre modificarile din lista de produse, asigurand astfel o actualizare sincronizata a interfetei.

