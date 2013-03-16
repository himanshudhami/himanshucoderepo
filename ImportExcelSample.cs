 
// you need to download Excel.dll from http://exceldatareader.codeplex.com/
private static void ImportExcelFile()
        {
            string fileName = @"c:\temp\Routing Updated.xlsx";
            String fileExtension = System.IO.Path.GetExtension(fileName);
            FileStream stream = new FileStream(fileName, FileMode.Open);



            //allowed files
            List<string> allowedExtensions = new List<string>();
            allowedExtensions.Add(".xls");
            allowedExtensions.Add(".xlsx");

            if (allowedExtensions.Contains(fileExtension))
            {
                //FileStream stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = null;

                if (fileExtension.Equals(".xls"))
                {
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (fileExtension.Equals(".xlsx"))
                {
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet result = excelReader.AsDataSet();
                DataTable dt = result.Tables[0];
                //var entity = this.textsProviderService.FindOneById(language) ?? new TranslatedText(language, string.Empty);

                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    //insert data to the database in appropriate columns
                }

            }
        }
