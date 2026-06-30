# Projet POO - Mots Glisses

Application console C# realisee dans le cadre d'un projet de Programmation Orientee Objet. Le programme propose un jeu de lettres a deux joueurs : chacun doit trouver des mots dans une grille, marquer des points, puis laisser les lettres restantes glisser vers le bas.

## Sommaire

- [Principe du jeu](#principe-du-jeu)
- [Fonctionnalites](#fonctionnalites)
- [Architecture](#architecture)
- [Fichiers de donnees](#fichiers-de-donnees)
- [Installation et lancement](#installation-et-lancement)
- [Deroulement d'une partie](#deroulement-dune-partie)
- [Format des fichiers](#format-des-fichiers)
- [Algorithmes utilises](#algorithmes-utilises)
- [Structure du depot](#structure-du-depot)
- [Documents fournis](#documents-fournis)

## Principe du jeu

Le plateau est une grille de 10 x 10 lettres. Un mot valide doit :

- exister dans le dictionnaire charge par le programme ;
- commencer sur la ligne du bas du plateau ;
- etre forme avec des lettres adjacentes en se deplacant vers la gauche, vers la droite ou vers le haut ;
- utiliser chaque case au maximum une fois pour le meme mot.

Quand un mot est trouve, les lettres utilisees sont supprimees du plateau. Les lettres situees au-dessus descendent ensuite pour combler les cases vides : c'est le mecanisme de "mots glisses".

## Fonctionnalites

- Menu principal en console.
- Partie a deux joueurs avec noms personnalises.
- Temps total de partie configurable.
- Temps maximum par tour configurable.
- Choix entre deux plateaux fournis, un plateau CSV personnel ou un plateau aleatoire.
- Sauvegarde possible d'un plateau genere aleatoirement.
- Validation des mots avec un dictionnaire francais.
- Calcul du score selon le poids des lettres et la longueur du mot.
- Affichage des caracteristiques du dictionnaire.
- Recherche directe d'un mot dans le dictionnaire.
- Affichage des informations de frequence et de poids des lettres.

## Architecture

Le projet est organise autour de classes dediees :

| Fichier | Role |
| --- | --- |
| `Program.cs` | Point d'entree, menus, saisies utilisateur et configuration d'une partie. |
| `Jeu.cs` | Orchestration d'une partie : tours, temps, validation des mots, scores et fin de partie. |
| `Plateau.cs` | Lecture/ecriture des grilles, generation aleatoire, recherche des mots et gravite. |
| `Dictionnaire.cs` | Chargement du dictionnaire, tri fusion et recherche dichotomique. |
| `Joueur.cs` | Gestion du nom, des mots trouves et du score d'un joueur. |
| `Lettre.cs` | Lecture des lettres disponibles, frequences maximales et poids de score. |

## Fichiers de donnees

Les fichiers de donnees sont indispensables a l'execution du jeu :

| Fichier | Utilisation |
| --- | --- |
| `Lettres.txt` | Liste les lettres, leur nombre maximal et leur poids. |
| `plateau1.csv` | Premier plateau predefini. |
| `plateau2.csv` | Deuxieme plateau predefini. |
| `MotsFrancais.txt` | Dictionnaire francais fourni dans le depot. |

Attention : dans l'etat actuel du code, `Dictionnaire.cs` cherche le fichier `Mots_Français.txt`. Si le programme indique que le dictionnaire est introuvable, renommez ou copiez `MotsFrancais.txt` avec ce nom dans le repertoire d'execution.

## Installation et lancement

### Prerequis

- Windows.
- Visual Studio avec le workload de developpement .NET desktop.
- .NET Framework 4.7.2 ou son targeting pack.

### Avec Visual Studio

1. Ouvrir `Projet-POO-Mots-Glisses.slnx`.
2. Verifier que le projet `Projet-POO-Mots-Glisses` est selectionne comme projet de demarrage.
3. Lancer l'application avec `F5` ou `Ctrl + F5`.

### En ligne de commande

Depuis la racine du depot :

```powershell
dotnet build Projet-POO-Mots-Glisses.slnx
```

Puis lancer l'executable genere depuis un repertoire contenant les fichiers de donnees :

```powershell
.\Projet-POO-Mots-Glisses\bin\Debug\Projet-POO-Mots-Glisses.exe
```

Les chemins des fichiers sont relatifs au repertoire courant d'execution. Si necessaire, copiez `Lettres.txt`, les fichiers `plateau*.csv` et le dictionnaire a cote de l'executable, ou lancez le programme depuis le dossier qui contient ces fichiers.

## Deroulement d'une partie

1. Le dictionnaire est charge puis trie.
2. Le menu principal propose de lancer une partie ou de consulter les donnees.
3. Deux joueurs saisissent leurs noms.
4. Le temps total et le temps maximum par tour sont definis.
5. Un plateau est choisi :
   - plateau 1 ;
   - plateau 2 ;
   - plateau CSV personnalise ;
   - plateau genere aleatoirement.
6. Les joueurs jouent chacun leur tour jusqu'a la fin du temps total.
7. Le programme compare les scores et affiche le vainqueur.

## Format des fichiers

### Lettres

`Lettres.txt` contient une ligne par lettre, au format :

```text
Lettre,Maximum,Poids
```

Exemple :

```text
A,7,1
B,5,2
C,4,3
```

### Plateaux

Les plateaux sont des fichiers CSV de 10 lignes et 10 colonnes. Les lettres sont separees par des points-virgules :

```text
E;O;K;T;P;Z;I;E;N;W
U;B;X;G;Q;M;V;E;A;J
Q;O;Y;T;D;M;I;R;N;W
```

### Dictionnaire

Le dictionnaire est organise par longueur de mot :

```text
2
AA AH AI AN AS ...
3
...
```

Le programme trie ensuite chaque groupe de mots avant d'utiliser la recherche dichotomique.

## Algorithmes utilises

- Tri fusion recursif pour organiser les mots du dictionnaire.
- Recherche dichotomique recursive pour valider rapidement un mot.
- Parcours avec pile (`Stack`) pour tester les chemins possibles dans le plateau.
- Gestion de la gravite apres suppression des lettres trouvees.
- Calcul de score avec poids des lettres et bonus lie a la longueur du mot.

## Structure du depot

```text
.
|-- Projet-POO-Mots-Glisses.slnx
|-- README.md
|-- MOTS_GLISSES.pdf
|-- diagramme UML.png
|-- Notes.txt
`-- Projet-POO-Mots-Glisses/
    |-- Projet-POO-Mots-Glisses.csproj
    |-- Program.cs
    |-- Jeu.cs
    |-- Plateau.cs
    |-- Dictionnaire.cs
    |-- Joueur.cs
    |-- Lettre.cs
    |-- Lettres.txt
    |-- MotsFrancais.txt
    |-- plateau1.csv
    `-- plateau2.csv
```

## Documents fournis

- `MOTS_GLISSES.pdf` : sujet ou consignes du projet.
- `diagramme UML.png` : diagramme UML principal.
- `Notes.txt` : notes de travail ou brouillon de rapport.
