private void btnRead_Click(object sender, EventArgs e)
{
 string line;
 try
 {
 StreamReader streamReader = new
StreamReader("C:\\Users\\User\\OneDrive\\Desktop\\Y3S1\\Visual Programming\\practical\\project5\\TextFiles\\readme.txt");
 line = streamReader.ReadLine();
 RTB.Clear();
 while (line != null)
 {
 RTB.Text = RTB.Text + line + Environment.NewLine;
 line = streamReader.ReadLine();
 }
 streamReader.Close();
 }
 catch (Exception ex)
 {
 MessageBox.Show("Error opening a file" + ex.Message);
 }
}
private void btnWrite_Click(object sender, EventArgs e)
{
 try
 {
 StreamWriter streamWriter = new
StreamWriter("C:\\Users\\User\\OneDrive\\Desktop\\Y3S1\\Visual Programming\\practical\\project5\\TextFiles\\writeme.txt");
 string content = RTB.Text;
 streamWriter.WriteLine(content);
 streamWriter.Close();
 }
 catch (Exception ex)
 {
 MessageBox.Show(ex.Message);
 }
}
