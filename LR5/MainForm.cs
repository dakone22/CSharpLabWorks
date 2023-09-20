using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LR5
{
    public partial class MainForm : Form
    {
        private readonly IList<string> _wordList = new List<string>();
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public MainForm() => InitializeComponent();

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            
            var filePath = openFileDialog.FileName;
            _stopwatch.Restart();

            try {
                var fileContent = File.ReadAllText(filePath);
                var words = fileContent.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                    if (!_wordList.Contains(word))
                        _wordList.Add(word);

                UpdateLoadTimeLabel();
                MessageBox.Show("Файл успешно загружен и слова добавлены в список.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show($"Произошла ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                _stopwatch.Stop();
                UpdateLoadTimeLabel();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var searchTerm = SearchTextBox.Text.Trim();
            var foundWords = new List<string>();
            _stopwatch.Restart();

            foreach (var word in _wordList)
                if (word.Contains(searchTerm))
                    foundWords.Add(word);

            _stopwatch.Stop();
            UpdateSearchTimeLabel();

            ResultsListBox.BeginUpdate();
            ResultsListBox.Items.Clear();
            ResultsListBox.Items.AddRange(foundWords.ToArray());
            ResultsListBox.EndUpdate();
        }

        private void UpdateLoadTimeLabel() => LoadTimeLabel.Text = $"Время загрузки: {_stopwatch.ElapsedMilliseconds} мс";

        private void UpdateSearchTimeLabel() => SearchTimeLabel.Text = $"Время поиска: {_stopwatch.ElapsedMilliseconds} мс";
    }
}