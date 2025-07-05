
using Google.Cloud.Firestore;

namespace TabooReloaded.Shared.Model
{
    [FirestoreData]
    public class TabooWordModel
    {
        [FirestoreProperty]
        public string Word { get; set; }

        [FirestoreProperty]
        public List<string> ForbiddenWords { get; set; }
    }
}
