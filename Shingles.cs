using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Compression; // FileInfo
using System.Xml.Linq; // FileInfo
using AsposeDocument = Aspose.Words.Document; // Text
using System.Text.RegularExpressions; // Text
using System.Data.SQLite; // Words
using System.Data; // Words
using System.Security.Cryptography;
using System.Text;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Bibliography;

namespace WinFormsShingles
{
    public class Comparison
    {
        private Document _verifiable;
        private Document _comparable;
        private string _dictPath;
        private int _shingleLength;
        private bool _shingleOverlay;

        private int _intersection;
        private double _result;

        public Document Verifiable { get => _verifiable; }
        public Document Comparable { get => _comparable; }
        public double Result { get => _result; }

        public Comparison(string veriDocPath, string compDocPath, string dictPath, int shingleLength, bool shingleOverlay)
        {
            _verifiable = new Document(veriDocPath, dictPath, shingleLength, shingleOverlay);
            _comparable = new Document(compDocPath, dictPath, shingleLength, shingleOverlay);
            _dictPath = dictPath;
            _shingleLength = shingleLength;
            _shingleOverlay = shingleOverlay;

            Dictionary<string, int> veriHashRepeat = _verifiable.Shingles.HashRepeat;
            Dictionary<string, int> compHashRepeat = _comparable.Shingles.HashRepeat;

            foreach (KeyValuePair<string, int> vhr in veriHashRepeat)
            {
                if (compHashRepeat.ContainsKey(vhr.Key))
                {
                    if (vhr.Value <= compHashRepeat[vhr.Key])
                    {
                        _intersection += vhr.Value;
                    }
                    else
                    {
                        _intersection += compHashRepeat[vhr.Key];
                    }
                }
            }

            _result = ((double)(_verifiable.Shingles.Hashes.Count - _intersection) * 100) / (double)_verifiable.Shingles.Hashes.Count;
        }
    }

    public class Document
    {
        private Info _fileInfo;
        private Text _text;
        private Words _words;
        private Shingles _shingles;

        public Info Info { get => _fileInfo; }
        public Text Text { get => _text; }
        public Words Words { get => _words; }
        public Shingles Shingles { get => _shingles; }

        public Document(string filePath, string dictPath, int shingleLength, bool overlay)
        {
            _fileInfo = new Info(filePath);
            _text = new Text(filePath);

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + dictPath);
            conn.Open();
            _words = new Words(_text.Cleaned, conn);
            conn.Close();

            _shingles = new Shingles(_words.Cleaned, shingleLength, overlay);
        }
    }

    public class Info
    {
        private string _path;
        private string _name;
        private string _extension;
        private string? _creator = null;
        private string? _editor = null;
        private string? _created = null;
        private string? _edited = null;
        private int? _editTime = null;
        private int? _pages = null;
        private int? _words = null;

        public string Path { get => _path; }
        public string Name { get => _name; }
        public string Extension { get => _extension; }
        public string? Creator { get => _creator; }
        public string? Editor { get => _editor; }
        public string? Created { get => _created; }
        public string? Edited { get => _edited; }
        public int? EditTime { get => _editTime; }
        public int? Pages { get => _pages; }
        public int? Words { get => _words; }

        public Info(string path)
        {
            _path = path;
            _name = path.Split('\\').Last().Substring(0, path.Split('\\').Last().Length - 1 - path.Split('\\').Last().Split('.').Last().Count());
            _extension = path.Split('.').Last();

            if (_extension == "docx")
            {
                ZipArchive archive = ZipFile.OpenRead(path);

                using (archive)
                {
                    try
                    {
                        ZipArchiveEntry? coreEntry = archive.GetEntry(@"docProps/core.xml");
                        if (coreEntry != null)
                        {
                            StreamReader coreReader = new StreamReader(coreEntry.Open());
                            using (coreReader)
                            {
                                foreach (var el in XElement.Parse(coreReader.ReadToEnd()).Elements())
                                {
                                    if (el.Name.ToString().Split('}').Last() == "creator")
                                        _creator = el.Value;
                                    if (el.Name.ToString().Split('}').Last() == "lastModifiedBy")
                                        _editor = el.Value;
                                    if (el.Name.ToString().Split('}').Last() == "created")
                                    {
                                        DateTime dt = DateTime.Parse(el.Value, null, System.Globalization.DateTimeStyles.RoundtripKind);
                                        DateTime dt2 = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Local);
                                        _created = dt2.ToString("dd.MM.yyyy HH:mm");
                                    }
                                    if (el.Name.ToString().Split('}')[1] == "modified")
                                    {
                                        DateTime dt = DateTime.Parse(el.Value, null, System.Globalization.DateTimeStyles.RoundtripKind);
                                        DateTime dt2 = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Local);
                                        _edited = dt2.ToString("dd.MM.yyyy HH:mm");
                                    }
                                }
                            }
                        }
                    }
                    catch { }

                    try
                    {
                        ZipArchiveEntry? appEntry = archive.GetEntry(@"docProps/app.xml");
                        if (appEntry != null)
                        {
                            StreamReader appReader = new StreamReader(appEntry.Open());
                            using (appReader)
                            {
                                foreach (var el in XElement.Parse(appReader.ReadToEnd()).Elements())
                                {
                                    if (el.Name.ToString().Split('}').Last() == "TotalTime")
                                        _editTime = Convert.ToInt32(el.Value);
                                    if (el.Name.ToString().Split('}').Last() == "Pages")
                                        _pages = Convert.ToInt32(el.Value);
                                    if (el.Name.ToString().Split('}').Last() == "Words")
                                        _words = Convert.ToInt32(el.Value);
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
        }
    }

    public class Text
    {
        private string _initial;
        private string _cleaned;

        public string Initial { get => _initial; }
        public string Cleaned { get => _cleaned; }

        public Text(string path)
        {
            AsposeDocument doc = new AsposeDocument(path);
            var x = doc.GetText();
            _initial = doc.GetText().Replace("Evaluation Only. Created with Aspose.Words. Copyright 2003-2022 Aspose Pty Ltd.\r", "").Replace("\fCreated with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/\r\r", "").Replace('\r', '\n');
            _cleaned = Regex.Replace(_initial, @"\b-|-\b", ""); // удаление дефисов
            _cleaned = Regex.Replace(_cleaned, @"ё", "е");// замена ё
            _cleaned = Regex.Replace(_cleaned, @"Ё", "Е"); // замена Ё
            _cleaned = Regex.Replace(_cleaned, @"[^0-9а-яА-Я]", " "); // оставить цифры, буквы и пробелы
            _cleaned = Regex.Replace(_cleaned, @"\s+", " "); // объединить повторяющиеся пробелы
            _cleaned = Regex.Replace(_cleaned, @"\s$", ""); // удалить пробел в конце строки
        }
    }

    public class Words
    {
        private List<string> _initial;
        private List<string> _cleaned;

        public List<string> Initial { get => _initial; }
        public List<string> Cleaned { get => _cleaned; }

        public Words(string cleanedText, SQLiteConnection conn)
        {
            _initial = cleanedText.ToLower().Split(' ').ToList();
            _cleaned = new List<string>();

            foreach (string word in _initial)
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter($"SELECT Word FROM opencorpora WHERE Form='{word}'", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        string? result = dt.Rows[0].ItemArray[0]!.ToString();
                        _cleaned.Add(result!);
                    }
                }
            }
        }
    }

    public class Shingles
    {
        private List<string> _segments = new List<string>();
        private List<string> _hashes = new List<string>();
        private Dictionary<string, int> _hashRepeat = new Dictionary<string, int>();

        public List<string> Segments { get => _segments; }
        public List<string> Hashes { get => _hashes; }
        public Dictionary<string, int> HashRepeat { get => _hashRepeat; }

        public Shingles(List<string> cleanedWords, int shingleLength, bool overlay)
        {
            string cleanedSegment = "";

            if (overlay)
            {
                for (int i = 0; i < cleanedWords.Count; i++)
                {
                    for (int j = 0; j <= shingleLength; j++)
                    {
                        if (j == 0)
                        {
                            cleanedSegment = cleanedWords[i + j];
                        }
                        else
                        {
                            if ((i + j) == cleanedWords.Count || j == shingleLength)
                            {
                                _segments.Add(cleanedSegment);
                                break;
                            }
                            else
                            {
                                cleanedSegment += $" {cleanedWords[i + j]}";
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < cleanedWords.Count; i++)
                {
                    if (i % shingleLength == 0)
                    {
                        cleanedSegment = cleanedWords[i];
                        if ((i + 1) == cleanedWords.Count)
                            _segments.Add(cleanedSegment);
                    }
                    else
                    {
                        cleanedSegment += $" {cleanedWords[i]}";
                        if ((i + 1) == cleanedWords.Count || (i + 1) % shingleLength == 0)
                            _segments.Add(cleanedSegment);
                    }
                }
            }

            var md5 = MD5.Create();
            foreach (string line in _segments)
                _hashes.Add(Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(line))));

            //hashes

            for (int i = 0; i < _hashes.Count; i++)
            {
                if (_hashRepeat.ContainsKey(_hashes[i]))
                {
                    _hashRepeat[_hashes[i]] += 1;
                }
                else
                {
                    _hashRepeat.Add(_hashes[i], 1);
                }
            }
        }
    }
}
