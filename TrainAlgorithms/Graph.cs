using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainAlgorithms
{
    internal class Graph
    {
        private IDictionary<string, List<string>> voisinsGares = new Dictionary<string, List<string>>();
        private IDictionary<string, List<double>> coordGares = new Dictionary<string, List<double>>();
        private int iterations = 0;
        private int branch = 0;
        private int depth = 0;

        public Graph()
        {
            initialisationGares();
            List<string> t = new List<string>();
            depth = DepthFinder("Brugge", t);
            branch = BranchingFactor();
        }

        #region Gares
        private void initialisationGares()
        {

            List<string> gr = new List<string>();
            gr.AddRange(new string[] { "Brugge", "Gent", "Lichtervelde", "Deinze", "Kortrijk", "Oudenaarde", "Tournai",
                                       "Zottegem", "Aalst", "Denderleew", "Grammont", "Termonde","Bruxelles-Midi",
                                       "Malines", "Leuven", "Herentals", "Hasselt", "Aarschot", "Ottignies",
                                       "Charleroi-Sud", "Ath", "Enghien", "Mons", "Soignies", "Marloie",
                                       "Liège-Guillemins", "Lokeren", "Anvers-Central", "Libramont", "Namur", "Landen"});

            //coordonnées géographiques de chaque gare
            List<double>[] coord = new List<double>[] { new List<double> { 51.20457000000005, 3.2173700000000736 },
                                                  new List<double> { 51.03707000000003, 3.70909000000006 },
                                                  new List<double> { 51.02768000000003, 3.1408000000000698 },
                                                  new List<double> { 50.986980000000074, 3.5292100000000346 },
                                                  new List<double> { 50.827780000000075, 3.2660000000000764 },
                                                  new List<double> { 50.84260000000006, 3.6086200000000304 },
                                                  new List<double> { 50.60656000000006, 3.385590000000036 },
                                                  new List<double> { 50.871200000000044, 3.811260000000061 },
                                                  new List<double> { 50.936240000000055, 4.042680000000075 },
                                                  new List<double> { 50.883140000000026, 4.081090000000074 },
                                                  new List<double> { 50.77164000000005, 3.8843800000000215 },
                                                  new List<double> { 51.03155000000004, 4.097860000000026 },
                                                  new List<double> { 50.86369000000008, 4.349320000000034 },
                                                  new List<double> { 51.02891000000005, 4.485520000000065 },
                                                  new List<double> { 50.87763000000007, 4.7071900000000255 },
                                                  new List<double> { 51.177490000000034, 4.836070000000063 },
                                                  new List<double> { 50.927050000000065, 5.335970000000032 },
                                                  new List<double> { 50.98383000000007, 4.831500000000062 },
                                                  new List<double> { 50.666360000000054, 4.567890000000034 },
                                                  new List<double> { 50.40579000000008, 4.43781000000007 },
                                                  new List<double> { 50.63119000000006, 3.7735700000000634 },
                                                  new List<double> { 50.69147000000004, 4.0334700000000225 },
                                                  new List<double> { 50.454710000000034, 3.9522400000000744 },
                                                  new List<double> { 50.57817000000006, 4.072650000000067 },
                                                  new List<double> { 50.19805000000008, 5.316260000000057 },
                                                  new List<double> { 50.625860000000046, 5.569390000000055 },
                                                  new List<double> { 51.104730000000075, 3.9865400000000477 },
                                                  new List<double> { 51.11084000000005, 4.63593000000003 },
                                                  new List<double> { 49.919970000000035, 5.376100000000065 },
                                                  new List<double> { 50.465730000000065, 4.861820000000023 },
                                                  new List<double> { 50.75247000000007, 5.08086000000003 }};

            
            //gares voisines avec durée de voyage
            List<string>[] vs = new List<string>[] { new List<string>{ "Gent/24", "Lichtervelde/20" },
                                                     new List<string>{ "Oudenaarde/30","Brugge/24","Deinze/12","Lokeren/20","Termonde/25","Aalst/29","Zottegem/35" },
                                                     new List<string>{ "Brugge/20", "Deinze/22", "Kortrijk/28" },
                                                     new List<string>{ "Lichtervelde/22","Gent/12","Kortrijk/20" },
                                                     new List<string>{ "Lichtervelde/28","Deinze/20","Oudenaarde/19","Tournai/29" },
                                                     new List<string>{ "Kortrijk/19","Gent/30","Zottegem/14" },
                                                     new List<string>{ "Kortrijk/29","Mons/45","Ath/21" },
                                                     new List<string>{ "Oudenaarde/14","Gent/35","Aalst/35","Denderleew/20","Grammont/14" },
                                                     new List<string>{ "Gent/29","Zottegem/35","Denderleew/8" },
                                                     new List<string>{ "Aalst/8","Zottegem/20","Grammont/27","Bruxelles-Midi/16" },
                                                     new List<string>{ "Zottegem/14","Denderleew/27","Ath/23","Enghien/19" },
                                                     new List<string>{ "Gent/25","Lokeren/15","Malines/22","Bruxelles-Midi/39" },
                                                     new List<string>{ "Termonde/39","Denderleew/16","Malines/27","Leuven/27","Ottignies/44","Charleroi-Sud/54","Soignies/26","Enghien/21" },
                                                     new List<string>{ "Bruxelles-Midi/27","Termonde/22","Anvers-Central/17","Leuven/25" },
                                                     new List<string>{ "Malines/25","Bruxelles-Midi/27","Aarschot/10","Ottignies/40","Landen/20" },
                                                     new List<string>{ "Anvers-Central/30","Hasselt/72" },
                                                     new List<string>{ "Herentals/72","Aarschot/27","Landen/27","Liège-Guillemins/32" },
                                                     new List<string>{ "Hasselt/27","Anvers-Central/38","Leuven/10" },
                                                     new List<string>{ "Bruxelles-Midi/44","Charleroi-Sud/44","Namur/25","Leuven/40" },
                                                     new List<string>{ "Bruxelles-Midi/54","Ottignies/44","Soignies/68","Mons/33","Namur/32" },
                                                     new List<string>{ "Grammont/23","Enghien/16","Soignies/21","Tournai/21" },
                                                     new List<string>{ "Bruxelles-Midi/21","Ath/16","Grammont/19" },
                                                     new List<string>{ "Soignies/14","Tournai/45","Charleroi-Sud/33" },
                                                     new List<string>{ "Ath/21","Bruxelles-Midi/26","Charleroi-Sud/68","Mons/14" },
                                                     new List<string>{ "Libramont/32","Liège-Guillemins/68","Namur/34" },
                                                     new List<string>{ "Hasselt/62","Landen/31","Marloie/68","Namur/46" },
                                                     new List<string>{ "Gent/20","Termonde/15","Anvers-Central/36" },
                                                     new List<string>{ "Lokeren/36","Malines/17","Aarschot/38","Herentals/30" },
                                                     new List<string>{ "Marloie/32","Namur/67" },
                                                     new List<string>{ "Ottignies/25","Libramont/67","Charleroi-Sud/32","Marloie/34","Liège-Guillemins/46" },
                                                     new List<string>{ "Leuven/20","Hasselt/27","Liège-Guillemins/31" }};

            for (int i = 0; i < 31; i++)
            {
                voisinsGares.Add(gr[i], vs[i]);
                coordGares.Add(gr[i], coord[i]);
            }
        }

        //retourne le nom de la gare voisine si false 
        //retourne le temps de voyage jusqu'à la gare si true
        public string nameOrTime(string s, bool option)
        {
            if (option)
            {
                return s.Substring(s.IndexOf('/')+1);
            }
            else
            {
                return s.Substring(0, s.IndexOf('/'));
            }
        }
        #endregion

        #region Valeur heuristique
        //calcule le temps de voyage, en minutes, pour une distance à vol d'oiseau
        //vitesse moyenne de 80km/h
        public double calculTemps(List<double> a, List<double> b)
        {
            double rayon = 6372.795477598; //rayon de la terre
            double distance = rayon * Math.Acos((Math.Sin(a[0]) * Math.Sin(b[0])) + (Math.Cos(a[0]) * Math.Cos(b[0]) * Math.Cos(a[1] - b[1])));
            return ((((distance * Math.PI) / 180) * 1000) / 22.22) / 60;
        }

        //retourne la valeur heuristique, qui est le temps de voyage entre chaque gare 
        public IDictionary<string, double> creationValHeuristique(string goal){
            IDictionary<string, double> result = new Dictionary<string, double>();  
            foreach(KeyValuePair<string, List<double>> g in coordGares)
            {
                result.Add(g.Key, calculTemps(g.Value, coordGares[goal]));
            }
            return result;
        }
        #endregion
        
        #region Algorithmes
        int DepthFinder(string root, List<string> v)
        {
            if (v.Contains(root))
                return 0;
            v.Add(root);
            List<string> temp = new List<string>();
            List<int> vs = new List<int>();
            temp = voisinsGares[root];
            foreach (string a in temp)
                vs.Add(DepthFinder(nameOrTime(a, false), v));
            return vs.Max() + 1;
        }

        int BranchingFactor()
        {
            List<int> nrNodes = new List<int>();
            foreach(KeyValuePair<string, List<string>> kv in voisinsGares)
            {
                nrNodes.Add(kv.Value.Count());
            }
            return nrNodes.Sum()/(voisinsGares.Count());
        }


        /*algorithme DFS
         *Création d'une stack (LIFO) pour prendre les branches dans l'ordre
         *La méthode tient compte des gares déjà visitée pour ne pas être répétées
         */
        public void DFS(string start, string stop)
        {
            iterations = 0;
            Console.WriteLine("DFS");
            List<string> visited = new List<string>();
            Stack<string> stack = new Stack<string>();
            visited.Add(start);
            stack.Push(start);
            string s = null;
            while (stack.Count != 0 && s != stop)
            {
                iterations++;
                s = stack.Pop();
                if (!visited.Contains(s))
                {
                    visited.Add(s);
                }
                List<string> vs = new List<string>();
                List<string> temp = new List<string>();
                temp = voisinsGares[s];
                foreach (string a in temp)
                {
                    vs.Add(nameOrTime(a, false));
                }
                foreach (string v in vs)
                {
                    if (!visited.Contains(v))
                    {
                        stack.Push(v);
                    }
                }
                Console.WriteLine("next->" + s);
                Form1.gui.WriteStations("next->" + s+"\r\n");
            }
            Form1.gui.WriteStats("Itérations = "+iterations.ToString()+"\r\n");
            Form1.gui.WriteStats("Facteur de branchement = " + branch.ToString()+ "\r\n");
            Form1.gui.WriteStats("Profondeur de l'arbre = " + depth.ToString()+ "\r\n");
            Form1.gui.WriteStats("Complexité temporelle  = " + ((Math.Pow(branch, depth+1) - 1)/(branch - 1)).ToString() + "\r\n");
            Form1.gui.WriteStats("Mémoire = " + (((branch-1)*depth)+1).ToString() + "\r\n");
        }

        /*Algorithme IDDFS
         *Une collection listByDepth est créée pour ajouter les gares en fonction de la profondeur
         *La méthode cherche d'abord la profondeur à laquelle se trouve le goal avec la méthode DFSforIDDFS
         *Si DFSforIDDFS retourne false, les voisins sont ajoutés à la liste des gares jusqu'à trouver la profondeur exacte du goal
         *Une fois que la profondeur est trouvée, la méthode applique un DFS sur la collection listByDepth pour trouver le chemin vers goal
         */
        public void IDDFS(string start, string stop)
        {
            iterations = 0;
            int mdepth = 0;
            Console.WriteLine("Iterative Deepening Search");
            List<string> visited = new List<string>();
            Stack<string> stack = new Stack<string>();
            visited.Add(start);
            stack.Push(start);
            string s = null;
            List<string> mty = new List<string>(); //liste toujours vide
            IDictionary<string, List<string>> listByDepth = new Dictionary<string, List<string>>();
            listByDepth.Add(start, voisinsGares[start]);
            bool found = false;
            while (!found)
            {
                if (!DFSforIDDFS(start, stop, listByDepth, mdepth))
                {
                    List<string> a = new List<string>(); //liste contenant les gares voisines vue pendant ce tour
                    mdepth++;
                    int x = listByDepth.Count();
                    for (int i = 0; i < x; i++)
                    {
                        foreach (string voisin in listByDepth[listByDepth.Keys.ElementAt(i)])
                        {
                            string nom = nameOrTime(voisin, false);
                            if (!listByDepth.ContainsKey(nom))
                            {
                                listByDepth.Add(nom, mty); //ajout uniquement du nom des gares voisines pour éviter que DFSforIDDFS ne cherche à > depth
                                a.Add(nom);
                            }
                            else if(!a.Contains(nom)) //OK si la gare n'est pas voisine de plusieurs gares se trouvant à depth-1
                            {
                                listByDepth[nameOrTime(voisin, false)] = voisinsGares[nameOrTime(voisin, false)];
                            }
                        }
                    }
                }
                else
                {
                    found = true;
                }
            }
            

            while (stack.Count != 0 && s != stop)
            {
                iterations++;
                s = stack.Pop();
                if (!visited.Contains(s))
                {
                    visited.Add(s);
                }
                List<string> vs = new List<string>();
                List<string> temp = new List<string>();
                temp = listByDepth[s];
                foreach (string a in temp)
                {
                    vs.Add(nameOrTime(a, false));
                }
                foreach (string v in vs)
                {
                    if (!visited.Contains(v))
                    {
                        stack.Push(v);
                    }
                }
                Form1.gui.WriteStations("next->" + s + "\r\n");

            }
            Form1.gui.WriteStats("Itérations = " + iterations.ToString() + "\r\n");
            Form1.gui.WriteStats("Facteur de branchement = " + branch.ToString() + "\r\n");
            Form1.gui.WriteStats("Profondeur de l'arbre = " + mdepth.ToString() + "\r\n");
            Form1.gui.WriteStats("Complexité temporelle  = " + (Math.Pow(branch, mdepth)-1).ToString() + "\r\n");
            Form1.gui.WriteStats("Mémoire = " + (((branch - 1) * mdepth) + 1).ToString() + "\r\n");
        }

        /*Algorithme DFS utilisé pour IDDFS afin de savoir si goal se trouve à la profondeur depth
         * Retourne true si stack contient l'objectif sans aller plus loin
         * Retourne false si la collection temp ne contient pas la gare d'arrivée
         */
        private bool DFSforIDDFS(string start, string stop, IDictionary<string, List<string>> temp, int depth)
        {
            List<string> visited = new List<string>();
            Stack<string> stack = new Stack<string>();
            visited.Add(start);
            stack.Push(start);
            string s = null;
            int x = 1;
            do
            {
                s = stack.Pop();
                if (!visited.Contains(s))
                {
                    visited.Add(s);
                }
                List<string> vs = new List<string>();
                List<string> t = new List<string>();
                t = temp[s];
                foreach (string a in t)
                {
                    vs.Add(nameOrTime(a, false));
                }
                foreach (string v in vs)
                {
                    if (!visited.Contains(v))
                    {
                        stack.Push(v);
                    }
                }
                if (stack.Contains(stop))
                {
                    if (temp.ContainsKey(stop))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            } while (stack.Count != 0 && x < depth);
            return false;
        }

        /*Mêmes étapes que DFS mais au lieu d'introduire les enfants dans un ordre prédéfini,
         * trie les gares voisines en fonction de la valeur heuristique
         */
        public void HillClimbing(string start, string stop)
        {
            iterations = 0;
            Console.WriteLine("Hill Climbing");
            List<string> visited = new List<string>();
            Stack<string> stack = new Stack<string>();
            IDictionary<string, double> heuristique = creationValHeuristique(stop);
            visited.Add(start);
            stack.Push(start);
            string s = null;
            while (stack.Count != 0 && s != stop)
            {
                iterations++;
                List<string> vs = new List<string>();
                IDictionary<string, double> listeOrd = new Dictionary<string, double>();
                List<string> temp = new List<string>();

                s = stack.Pop();
                if (!visited.Contains(s))
                {
                    visited.Add(s);
                }

                temp = voisinsGares[s];
                foreach (string a in temp)
                {
                    vs.Add(nameOrTime(a, false));
                }
                foreach (string g in vs)
                {
                    listeOrd.Add(g, heuristique[g]);
                }
                listeOrd = listeOrd.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                foreach (string v in listeOrd.Keys)
                {
                    if (!visited.Contains(v))
                    {
                        stack.Push(v);
                    }
                }
                Form1.gui.WriteStations("next->" + s + "\r\n");
            }
            Form1.gui.WriteStats("Itérations = " + iterations.ToString() + "\r\n");
            Form1.gui.WriteStats("Facteur de branchement = " + branch.ToString() + "\r\n");
            Form1.gui.WriteStats("Profondeur de l'arbre = " + depth.ToString() + "\r\n");
            Form1.gui.WriteStats("Complexité temporelle  = " + ((Math.Pow(branch, depth + 1) - 1) / (branch - 1)).ToString() + "\r\n");
            Form1.gui.WriteStats("Mémoire = " + (((branch - 1) * depth) + 1).ToString() + "\r\n");
        }

        /*Utilise une queue (FIFO) afin de pouvoir revenir sur une autre maille si elle a une meilleure valeur heuristique
         * Ordonne la liste des voisins afin de les introduire dans la queue et éviter que l'algorithme traverse toute une maille
         * avant de revenir vers la maille ayant une meilleure valeur heuristique
         */
        public void GreedySearch(string start, string stop)
        {
            iterations = 0;
            Console.WriteLine("Greedy Search");
            List<string> visited = new List<string>();
            Queue<string> queue = new Queue<string>();
            IDictionary<string, double> heuristique = creationValHeuristique(stop);
            visited.Add(start);
            queue.Enqueue(start);
            string s = null;
            while (queue.Count > 0 && s != stop)
            {
                iterations++;
                s = queue.Dequeue();
                if (!visited.Contains(s))
                {
                    visited.Add(s);
                }
                List<string> vs = new List<string>();
                List<string> temp = new List<string>();
                IDictionary < string, double> listeTarget = new Dictionary<string, double>(); 

                temp = voisinsGares[s];
                foreach (string a in temp)
                {
                    vs.Add(nameOrTime(a, false));
                }
                foreach (string b in queue)
                {
                    if (!vs.Contains(b))
                    {
                        vs.Add(b);
                    }
                }
                queue.Clear();
                foreach (string g in vs)
                {
                    listeTarget.Add(g, heuristique[g]);
                }
                listeTarget = listeTarget.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                foreach(string a in listeTarget.Keys)
                {
                    if (!visited.Contains(a))
                    {
                        queue.Enqueue(a);
                    }
                }
                Form1.gui.WriteStations("next->" + s + "\r\n");
            }
            Form1.gui.WriteStats("Itérations = " + iterations.ToString() + "\r\n");
            Form1.gui.WriteStats("Facteur de branchement = " + branch.ToString() + "\r\n");
            Form1.gui.WriteStats("Profondeur de l'arbre = " + iterations.ToString() + "\r\n");
            Form1.gui.WriteStats("Complexité temporelle  = " + ((Math.Pow(branch, iterations + 1) - 1) / (branch - 1)).ToString() + "\r\n");
            Form1.gui.WriteStats("Mémoire = " + ((Math.Pow(branch, iterations + 1) - 1) / (branch - 1)).ToString() + "\r\n");
        }

        /*Se comporte comme Greedy Search mais prend en compte le temps entre chaque gare,
         * en plus du temps à vol d'oiseau
         */
        public void Astar(string start, string stop)
        {
            iterations = 0;
            Console.WriteLine("A*");
            List<string> visited = new List<string>();
            Queue<string> queue = new Queue<string>();
            IDictionary<string, double> heuristique = creationValHeuristique(stop);
            visited.Add(start);
            queue.Enqueue(start);
            string s = null;
            while (queue.Count > 0 && s != stop)
            {
                iterations++;
                s = queue.Dequeue();
                if (!visited.Contains(s))
                {
                    visited.Add(s);
                }
                List<string> temp = new List<string>();
                string gareSuivante = null;
                double shortest = 0;

                temp = voisinsGares[s];
                foreach (string a in temp)
                {
                    string gareRapide = nameOrTime(a, false);
                    double cost = Double.Parse(nameOrTime(a, true)) + heuristique[gareRapide]; //valeur heuristique modifiée
                    if(((shortest == 0) || (cost < shortest))&&(!visited.Contains(gareRapide)))
                    {
                        shortest = cost;
                        gareSuivante = gareRapide;
                    }
                }
                queue.Enqueue(gareSuivante);

                Form1.gui.WriteStations("next->" + s + "\r\n");
            }
            Form1.gui.WriteStats("Itérations = " + iterations.ToString() + "\r\n");
            Form1.gui.WriteStats("Facteur de branchement = " + branch.ToString() + "\r\n");
            Form1.gui.WriteStats("Profondeur de l'arbre = " + iterations.ToString() + "\r\n");
            Form1.gui.WriteStats("Complexité temporelle  = " + ((Math.Pow(branch, iterations + 1) - 1) / (branch - 1)).ToString() + "\r\n");
            Form1.gui.WriteStats("Mémoire = " + ((Math.Pow(branch, iterations + 1) - 1) / (branch - 1)).ToString() + "\r\n");
        }
        #endregion
    }
}
