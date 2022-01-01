CREATE TABLE [dbo].[Instance_declaration]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Mois] INT NOT NULL, 
    [Id_Identificateur_entreprise] INT NOT NULL, 
    CONSTRAINT [FK_Instance_declaration_To_Identificateur_entreprise] FOREIGN KEY ([Id_Identificateur_entreprise]) REFERENCES [Identificateur_entreprise]([Id])
)


GO

CREATE TRIGGER [dbo].[Trigger_new_Instance_declaration]
    ON [dbo].[Instance_declaration]
    FOR INSERT, UPDATE
    AS
    BEGIN
		DECLARE 
			@Id_instance int
			SET @Id_instance = (SELECT Id FROM inserted);

			INSERT INTO dbo.Ventilation_CA_totale(Code, Designation, Montant, Id_instance) VALUES(10, 'Montant du chiffre d’affaires réalisé y compris les affaires non imposables (HT)', 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_totale(Code, Designation, Montant, Id_instance) VALUES(20, '- Opérations situées hors champ d’application de la TVA', 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_totale(Code, Designation, Montant, Id_instance) VALUES(30, '- Opérations exonérées sans droit à déduction. (art 91 du CGI)', 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_totale(Code, Designation, Montant, Id_instance) VALUES(40, '- Opérations exonérées avec droit à déduction. (art 92 du CGI)', 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_totale(Code, Designation, Montant, Id_instance) VALUES(50, '- Opérations faites en suspension de la TVA. (art 94 du CGI)', 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_totale(Code, Designation, Montant, Id_instance) VALUES(60, 'Chiffre d’affaires imposable à répartir (différence : ligne 10 – (20 + 30 +40 +50) (HT)', 0, @Id_instance); 

			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(80, '-Opérations de production et de distribution', 0, 0, @Id_instance);
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(81, '-Prestations de services', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(82, '-Professions libérales visées à l’article 89-I-12°-(b) du CGI', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(83, '-Opérations de crédit-bail', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(87, '-Opérations d’entreprises de travaux immobiliers', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(102, '-Autres', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(84, '-Beurre à l’exclusion du beurre de fabrication artisanale visé à l’article 91 (IA. 2°)', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(88, '-Opérations de transport de voyageurs et de marchandises à l’exclusion du transport ferroviaire', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(90, '-Energie électrique ', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(104, '-Autres', 0, 0, @Id_instance); 

			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(91, '- Les Prestations de services rendues par tout agent démarcheur ou courtier d’assurances à raison des contrats apportés par lui à une entreprise d’assurances', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(77, '- Les chauffe-eau solaires', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(78, '- Les aliments destinés à l’alimentation du bétail et des animaux de basse-cour ainsi que les tourteauxservant à leur fabrication à l’exclusion des autres aliments simples', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(79, '- Les équipements à usage exclusivement agricole', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(85, '- Les bois en grumes, écorcés ou simplement équarris, le liège à l’état naturel, les bois de feu en fagots ousciés à petite longueur et le charbon de bois', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(86, '- Les engins et filets de pêche destinés aux professionnels de la pêche maritime.', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(89, '- Les prestations de restauration fournies directement par l’entreprise à son personnel salarié', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(92, '- Les opérations de restauration et de logement dans des hôtels', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(93, '- opérations de restauration fournies par Les prestataires de services au personnel salarié des entreprises', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(94, '- Location d hôtels ou d ensembles immobiliers à destination touristique.', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(95, '- Les opérations de vente de denrées ou de boissons à consommer sur place, réalisées dans les restaurants', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(96, '- Le sel de cuisine (gemme ou marin)', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(97, '- Le riz usiné et Les pâtes alimentaires', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(98, '- Les huiles fluides alimentaires', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(99, '- Les transactions relatives aux valeurs mobilières', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(100, '- Les opérations de banque et de crédit et Les commissions de change', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(101, '- Les transactions portant sur Les actions et Les parts sociales', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(103, '- Les opérations de vente et de livraison des oeuvres et objets d’art', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(105, '- Les opérations des avocats, interprètes, notaires, adoul, huissiers de justice et vétérinaires', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(108, '- Gaz de pétrole et Les autres hydrocarbures gazeux', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(109, '- Les Huiles de pétrole ou de schistes, brutes ou raffinées', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(118, '-Autres', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(106, '- L’eau livrée aux réseaux de distribution publique et les prestations d’assainissement', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(107, '- Location de compteurs d’eau et d’électricité', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(110, '- Produits pharmaceutiques, matières premières et produits entrant dans leurs compositions ainsi que les  emballages non récupérables de ces produits et matières', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(111, '- Les fournitures scolaires, produits et matières entrant dans leur composition', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(113, '- Sucre raffiné ou aggloméré', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(114, '- Conserves de sardines', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(115, '- Lait en poudre', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(116, '- Savon de ménage', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(117, '- Voiture économique et produits et matières entrant dans sa fabrication', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(119, '-Autres', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(120, 'Reversement de la TVA à différents titres (cessation, régularisation,….)', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(129, 'Opérations réalisées avec des contribuables non résidents (1)', 0, 0, @Id_instance); 
			INSERT INTO dbo.Ventilation_CA_imposable(Code, Designation, Base_imposable, Taxe_exigible, Id_instance) VALUES(130, 'TOTAL de la TVA exigible', 0, 0, @Id_instance); 

			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(140, '- Prestation de service ', 20, 0, NULL, 0, @Id_instance);
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(141, '- transport', 14, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(142, '- Opération de banque', 10, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(143, '- Hôtels de voyageurs, et ensemble immobilier à destination touristique', 10, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(144, '- Les opérations des avocats, interprètes, notaires, adoul, huissiers de justice et vétérinaires', 10, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(153, '- autres prestations de services', 10, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(145, '- Achat à l’importation', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(146, '- Achat à l’intérieur', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(147, '- Achat à l’importation', 14, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(148, '- Achat à l’intérieur', 14, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(149, '- Achat à l’importation', 10, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(150, '- Achat à l’intérieur', 10, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(151, '- Achat à l’importation', 7, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(152, '- Achat à l’intérieur', 7, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(155, 'Travaux à façon', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(156, 'Sous –traitance ( travaux immobiliers )', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(157, '- Déduction prévue par l article 125-VII du CGI (1/5 du montant de la TVA payée au cours du mois de décembre 2013)  ', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(162, '- Achat à l’importation', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(163, '- Achat à l’intérieur', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(164, '- Livraison à soi-même autre que Les constructions', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(165, '- Installation et pose', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(166, '- Constructions', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(167, '- Livraison à soi-même de constructions', 20, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(168, '- Autres immobilisations', 14, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(169, '- Autres immobilisations', 7, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(170, '- crédit de la période précédente ……………', NULL, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(180, '- Déduction complémentaire de la régularisation du prorata', NULL, 0, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(181, '-Fraction du crédit de taxe cumulé (**)', NULL, 0, NULL, 0, @Id_instance); 

			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(190, 'Total de la TVA déductible', NULL, NULL, NULL, 0, @Id_instance);
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(200, 'TVA due (130-190) ', NULL, NULL, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(201, 'Crédit à reporter (en rouge ) (190-130) ', NULL, NULL, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(202, 'Réduction de 15% du crédit de la période ((190 - 170) - 130) × 15% ', NULL, NULL, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(203, 'Crédit restant cumulé après réduction de 15% (201- 202)', NULL, NULL, NULL, 0, @Id_instance); 
			INSERT INTO dbo.[Ventilation_deduction](Code, Designation, Taux, TVA, Prorata, TVA_dedcutible, Id_instance) VALUES(204, 'Crédit accompagné de paiement  y compris la TVA due dans le cadre de l article 115 du CGI.', NULL, NULL, NULL, 0, @Id_instance); 

			INSERT INTO dbo.Declaration_totaux(Totale_TVA_exigible, Totale_TVA_deductible, Credit_N1, Id_instance) VALUES( 0, 0, 0, @Id_instance);
        SET NoCount ON
    END