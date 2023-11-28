namespace BinaryTree
{
    //Nunca havia visto na prática árvore binária em código na prática(só sua dinâmica na teoria),
    //então tive que aprender algumas coisas durante este desafio:
    //1- Como fazer structs em c# e como funciona a dinâmica dos métodos nelas
    //2- Como seria a dinâmica do algoritmo, com o chatGPT fui vendo e
    //refazendo com algumas mudanças no algoritmo

    //3- "ref" é uma forma de alterar a árvore através de referências ao invés de copias,
    //desse jeito os métodos conseguem modificar a
    //árvore diretamente(tipo referência ao espaço na memória usada em c)


    //Funcionamento do algoritmo: Primeiro definimos o "esqueleto" da árvore,
    //que é: O valor no nó, O nó a esquerda e o nó a direita
    //Para inserir valores temos o método Insert,
    //ele é responsável por saber onde salvar ós novos valores(lado esquerdo ou direto da árvore)
    //e saber qual a posição certa no lado que o novo nó irá ter
    //Já o método GetFreeIndex vai ver se há algum nó vazio e, se existir, retorna a posição
    //A árvore é gerada e preenchida, mas por alguma razão não está imprimindo os mesmos valores salvos

    //ATENÇÃO: por algum motivo o método recursivo que percorreria a árvore não funciona,
    //tentei várias alterações ao longo do dia e consegui ver que estão sendo inseridos no lugar certo

    public class Program {
        struct BinaryTree {
            public int Number;
            public int LeftNode;
            public int RightNode;

            public BinaryTree(int number, int leftNode, int rightNode) {
                Number = number;
                LeftNode = leftNode;
                RightNode = rightNode;
            }

            public static void Insert(ref BinaryTree[] tree, int currentIndex, int valueToBeInserted)
            {
                Console.WriteLine($"Inserting {valueToBeInserted} at index {currentIndex}");

                if (tree[currentIndex].Number == 0)
                {
                    tree[currentIndex] = new BinaryTree(valueToBeInserted, 0, 0);
                    Console.WriteLine($"Inserted at index {currentIndex}, value: {valueToBeInserted}");
                }
                else if (valueToBeInserted < tree[currentIndex].Number)
                {
                    if (tree[currentIndex].LeftNode == 0)
                    {
                        int newNodeIndex = getFreeIndex(tree);
                        tree[currentIndex].LeftNode = newNodeIndex;

                        tree[newNodeIndex] = new BinaryTree(valueToBeInserted, 0, 0);
                        Console.WriteLine($"Inserted at index {newNodeIndex}, value: {valueToBeInserted}");
                    }
                    else
                    {
                        Insert(ref tree, tree[currentIndex].LeftNode, valueToBeInserted);
                    }
                }
                else
                {
                    if (tree[currentIndex].RightNode == 0)
                    {
                        int newNodeIndex = getFreeIndex(tree);
                        tree[currentIndex].RightNode = newNodeIndex;

                        tree[newNodeIndex] = new BinaryTree(valueToBeInserted, 0, 0);
                        Console.WriteLine($"Inserted at index {newNodeIndex}, value: {valueToBeInserted}");
                    }
                    else
                    {
                        Insert(ref tree, tree[currentIndex].RightNode, valueToBeInserted);
                    }
                }
            }
            public static int getFreeIndex(BinaryTree[] tree)
            {
                for (int counter = 0; counter < tree.Length; counter++) {
                    if (tree[counter].Number == 0) {
                        Console.WriteLine($"Found free index: {counter}");
                        return counter;
                    }
                }
                throw new InvalidOperationException("There is no index available :(");
            }
        }

        static void InOrderTraversal(BinaryTree[] tree, int currentIndex)
        {
            if (currentIndex != 0 && tree[currentIndex].Number != 0)
            {
                InOrderTraversal(tree, tree[currentIndex].LeftNode);

                Console.Write(tree[currentIndex].Number + " ");

                InOrderTraversal(tree, tree[currentIndex].RightNode);
            }
        }


        static void Main(string[] args)
        {
            int maximumArraySize = 5;

            BinaryTree[] tree = new BinaryTree[maximumArraySize];
            
            tree[0] = new BinaryTree(0, 0, 0);
            

            BinaryTree.Insert(ref tree, 0, 3);
            BinaryTree.Insert(ref tree, 0, 2);
            BinaryTree.Insert(ref tree, 0, 1);
            BinaryTree.Insert(ref tree, 0, 4);
            BinaryTree.Insert(ref tree, 0, 5);

            InOrderTraversal(tree, 0);
        }

        
    }
}