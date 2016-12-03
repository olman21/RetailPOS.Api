using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailStore.Models
{
    public class Utilities
    {
        public static void CopyProperties<TEntity>(TEntity objSource, TEntity objDestination)
        {
            //get the list of all properties in the destination object
            var destProps = objDestination.GetType().GetProperties();

            //get the list of all properties in the source object
            foreach (var sourceProp in objSource.GetType().GetProperties())
            {
                foreach (var destProperty in destProps)
                {
                    //if we find match between source & destination properties name, set
                    //the value to the destination property
                    if (destProperty.Name == sourceProp.Name &&
                            destProperty.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                    {
                        destProperty.SetValue(destProps, sourceProp.GetValue(
                            sourceProp, new object[] { }), new object[] { });
                        break;
                    }
                }
            }
        }

    }
}