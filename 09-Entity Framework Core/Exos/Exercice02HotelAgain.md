# Exercice 02 H�tel

## Objectifs
- Ma�triser les concepts de EFCore
- Apprendre � manipulation des relations ONE-TO-MANY, ONE-TO-ONE, MANY-TO-MANY
- S'entra�ner avec linQ
- Utilisation du Repository Pattern

## Sujet
1. Cr�er une classe Client poss�dant : un identifiant, un nom, un pr�nom et un num�ro de t�l�phone
2. Cr�er une classe Chambre ayant : un num�ro, un statut (libre/occup�/en nettoyage de type enum), un nombre de lits et un tarif.
3. Cr�er une classe R�servation poss�dant : un identifiant, un statut (pr�vu/en cours/fini/annul�), une liste de chambres et un client
4. Cr�er une classe Hotel comportant : une liste de clients, une liste de chambres et une liste de r�servations
5. Cr�er une IHM pour tester l'application