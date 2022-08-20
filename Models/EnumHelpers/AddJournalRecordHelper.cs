using System;
using System.Collections.Generic;
using System.Linq;
using editor.Models.Actions;

namespace editor.Models.EnumHelpers
{
    public class AddJournalRecordHelper : ISelectHelper
    {
        private readonly IEnumerable<JournalRecord> journalRecords;
        private readonly AddJournalRecord addJournalRecord;
        public JournalRecord JournalRecord => journalRecords
        .FirstOrDefault(d => d.Id == addJournalRecord.JournalRecordId);

        public AddJournalRecordHelper(IEnumerable<JournalRecord> journalRecords, AddJournalRecord addJournalRecord)
        {
            this.addJournalRecord = addJournalRecord;
            this.journalRecords = journalRecords;
        }

        public string Value
        {
            get => addJournalRecord.JournalRecordId.ToString();
            set 
            {
                Guid id;
                if(Guid.TryParse(value, out id)){
                    addJournalRecord.JournalRecordId = id;
                }
                else{
                    addJournalRecord.JournalRecordId = Guid.Empty;
                }
                
            }
        }

        public IEnumerable<SelectorOption> Options()
        {
            return journalRecords.Select(d => new SelectorOption(d.Name, d.Id.ToString()));
        }
    }
}
