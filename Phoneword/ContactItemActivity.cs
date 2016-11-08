using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Phoneword
{
    [Activity(Label = "ContactItemActivity")]
    public class ContactItemActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var uri = ContactsContract.Contacts.ContentUri;

            string[] projection = { ContactsContract.Contacts.InterfaceConsts.Id,
       ContactsContract.Contacts.InterfaceConsts.DisplayName };

            var cursor = ManagedQuery(uri, projection, null, null, null);

            var contactList = new List<string>();

            if (cursor.MoveToFirst())
            {
                do
                {
                    contactList.Add(cursor.GetString(
                            cursor.GetColumnIndex(projection[1])));
                } while (cursor.MoveToNext());
            }

            ListAdapter = new ArrayAdapter<string>(this,
                   Resource.Layout.ContactItemView, contactList);
        }
    }
}