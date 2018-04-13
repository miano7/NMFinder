using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMFinder
{
    public class SearchEngine
    {
        public string currentDirectoryText;
        public delegate void directoryStatus(bool change);
        public event directoryStatus changeDirectory;
        public void TraverseTree(string root, string fileName)
        {
            // Data structure to hold names of subfolders to be
            // examined for files.            
            Stack<string> dirs = new Stack<string>();
            if (!Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                currentDirectoryText = currentDir;
                changeDirectory(true);
                string[] subDirs;
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                // An UnauthorizedAccessException exception will be thrown if we do not have
                // discovery permission on a folder or file. It may or may not be acceptable 
                // to ignore the exception and continue enumerating the remaining files and 
                // folders. It is also possible (but unlikely) that a DirectoryNotFound exception 
                // will be raised. This will happen if currentDir has been deleted by
                // another application or thread after our call to Directory.Exists. The 
                // choice of which exceptions to catch depends entirely on the specific task 
                // you are intending to perform and also on how much you know with certainty 
                // about the systems on which this code will run.
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                //for netframework 4.5
                catch (PathTooLongException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                //File collection
                IEnumerable<string> files;
                try
                {
                    files = Directory.EnumerateFiles(currentDir, fileName);
                }

                catch (UnauthorizedAccessException e)
                {
    
                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                //for netframework 4.5
                catch (PathTooLongException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                // Perform the required action on each file here.
                try
                    {

                    //Adding latest version of the file to the list
                    if (files.GetEnumerator().Current != null)
                    {
                            foreach (var item in SortLastFileVersion(files))
                            {
                                if (!item.EndsWith(".0"))
                                {
                                    NMFinder.Parts.Add(item);  
                                }
                            }
                }
                }
                    catch (FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        Console.WriteLine(e.Message);
                        continue;
                    }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);               
            }
        }

        public string[] SortLastFileVersion(IEnumerable<string> filesList)
        {
            string[] filesListArray = filesList.ToArray();
            int[] extListPrt = new int[filesListArray.Length];
            int[] extListAsm = new int[filesListArray.Length];
            int[] extListDrw = new int[filesListArray.Length];
            /*
            List<int> extListPrt = new List<int>();
            List<int> extListAsm = new List<int>();
            List<int> extListDrw = new List<int>();
             */
            //this is master branch
            string pathFile = null;
            
            var fPathExtension = filesListArray.LastOrDefault().IndexOf(".");
            pathFile = filesListArray.LastOrDefault().Remove(fPathExtension);

            for (int i = 0; i < filesListArray.Length; i++)
            {
                var extPosition = filesListArray[i].LastIndexOf(".");
                //Remove version from the file name.
                string fExtensionSort = filesListArray[i].Substring(extPosition + 1);       
                //Mask for parts
                if (filesListArray[i].EndsWith(".prt." + fExtensionSort))
                {
                    int convertedExtension;
                    bool parsed = Int32.TryParse(fExtensionSort, out convertedExtension);
                    //extListPrt.Add(convertedExtension);
                    extListPrt[i] = convertedExtension;
                }
                //Mask for assemblies
                if (filesListArray[i].EndsWith(".asm." + fExtensionSort))
                {
                    int convertedExtension;
                    bool parsed = Int32.TryParse(fExtensionSort, out convertedExtension);
                    //extListAsm.Add(convertedExtension);
                    extListAsm[i] = convertedExtension;
                }
                //Mask for drawings
                if (filesListArray[i].EndsWith(".drw." + fExtensionSort))
                {
                    int convertedExtension;
                    bool parsed = Int32.TryParse(fExtensionSort, out convertedExtension);
                    //extListDrw.Add(convertedExtension);
                    extListDrw[i] = convertedExtension;
                }
            }
            //Sort
            Array.Sort(extListPrt);
            int p = extListPrt[extListPrt.Length - 1];
            Array.Sort(extListAsm);
            int a = extListAsm[extListAsm.Length - 1];
            Array.Sort(extListDrw);
            int d = extListDrw[extListDrw.Length - 1];
            string[] result = {pathFile + ".prt." + p.ToString(), pathFile + ".asm." + a.ToString(), pathFile + ".drw." + d.ToString()};

            return result;
        }
    }
}
