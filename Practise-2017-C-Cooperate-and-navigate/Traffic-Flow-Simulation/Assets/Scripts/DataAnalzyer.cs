using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class DataAnalzyer{
	public static DataAnalzyer Instance;
    public List<float> mailpost_5 = new List<float>();
    List<float> mailpost_90 = new List<float>();
    List<float> mailpost_405 = new List<float>();
    List<float> mailpost_520 = new List<float>();

    List<int> traffic_counts_5 = new List<int>();
    List<int> traffic_counts_90 = new List<int>();
    List<int> traffic_counts_405 = new List<int>();
    List<int> traffic_counts_520 = new List<int>();

    List<List<int>> lanes_number_5 = new List<List<int>>();
    List<List<int>> lanes_number_90 = new List<List<int>>();
    List<List<int>> lanes_number_405 = new List<List<int>>();
    List<List<int>> lanes_number_520 = new List<List<int>>();
	void Awakw(){
		Instance = this;
        getFiles();
    }
    // Use this for initialization
    void Start () {

	}

	public void getFiles() {
        DirectoryInfo tag_Dir = new DirectoryInfo("C:\\Users\\mySab\\Documents\\SourceCode\\Project-Repository\\2018-MCM-ICM-Repository\\Practise-2017-C-Cooperate-and-navigate\\resource\\");
        FileInfo[] txt_files_info = tag_Dir.GetFiles("2017_MCM_Problem_C_Data.txt");

        //StreamReader temp_strReader;
        StreamReader temp_headReader;
        Debug.Log(txt_files_info.Length);
        string temp_line;
        FileInfo temp = txt_files_info[0];
        temp_headReader = temp.OpenText();
        while ((temp_line = temp_headReader.ReadLine()) != null) {

            string[] sArray = temp_line.Split(',');
            switch (sArray[0]) {
                case "5":
                    if (sArray.Length >= 8 && sArray[7] == "-1") {
                        mailpost_5.Add(float.Parse(sArray[1]));
                        mailpost_5.Add(float.Parse(sArray[2]));
                    } else {
                        mailpost_5.Add(float.Parse(sArray[1]));
                    }
                    traffic_counts_5.Add(int.Parse(sArray[3]));
                    List<int> temp_list1 = new List<int>();
                    temp_list1.Add(int.Parse(sArray[5]));
                    temp_list1.Add(int.Parse(sArray[6]));
                    lanes_number_5.Add(temp_list1);
                    break;
                case "90":
                    if (sArray.Length >= 8 && sArray[7] == "-1") {
                        mailpost_90.Add(float.Parse(sArray[1]));
                        mailpost_90.Add(float.Parse(sArray[2]));
                    } else {
                        mailpost_90.Add(float.Parse(sArray[1]));
                    }
                    traffic_counts_90.Add(int.Parse(sArray[3]));
                    List<int> temp_list2 = new List<int>();
                    temp_list2.Add(int.Parse(sArray[5]));
                    temp_list2.Add(int.Parse(sArray[6]));
                    lanes_number_5.Add(temp_list2);
                    break;
                case "405":
                    if (sArray.Length >= 8 && sArray[7] == "-1") {
                        mailpost_405.Add(float.Parse(sArray[1]));
                        mailpost_405.Add(float.Parse(sArray[2]));
                    } else {
                        mailpost_405.Add(float.Parse(sArray[1]));
                    }
                    traffic_counts_405.Add(int.Parse(sArray[3]));
                    List<int> temp_list3 = new List<int>();
                    temp_list3.Add(int.Parse(sArray[5]));
                    temp_list3.Add(int.Parse(sArray[6]));
                    lanes_number_5.Add(temp_list3);
                    break;
                case "520":
                    if (sArray.Length >= 8 && sArray[7] == "-1") {
                        mailpost_520.Add(float.Parse(sArray[1]));
                        mailpost_520.Add(float.Parse(sArray[2]));
                    } else {
                        mailpost_520.Add(float.Parse(sArray[1]));
                    }
                    traffic_counts_520.Add(int.Parse(sArray[3]));
                    List<int> temp_list4 = new List<int>();
                    temp_list4.Add(int.Parse(sArray[5]));
                    temp_list4.Add(int.Parse(sArray[6]));
                    lanes_number_5.Add(temp_list4);
                    break;
            }
        }
    }
}
