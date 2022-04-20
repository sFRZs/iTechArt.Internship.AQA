using System;
using System.Collections.Generic;
using System.ComponentModel;
using iTechArt.Internship.Swagger.API.Tests.Entities.Enums;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels;

namespace iTechArt.Internship.Swagger.API.Tests.Entities.Factories
{
    public class DataTypeFactory
    {
        public static IList<DataTypeVM> AllDataTypes()
        {
            var dataTypeList = new List<DataTypeVM>();

            for (int i = 0; i < Enum.GetNames(typeof(DataTypes)).Length; i++)
            {
                string type = null;
                DataTypes eType = (DataTypes) Enum.GetValues(typeof(DataTypes)).GetValue(i);

                switch (eType)
                {
                    case (DataTypes.Boolean):
                        type = "System.Boolean";
                        break;
                    case (DataTypes.Char):
                        type = "System.Char";
                        break;
                    case (DataTypes.DateTime):
                        type = "System.DateTime";
                        break;
                    case (DataTypes.Decimal):
                        type = "System.Decimal";
                        break;
                    case (DataTypes.Double):
                        type = "System.Double";
                        break;
                    case (DataTypes.Int32):
                        type = "System.Int32";
                        break;
                    case (DataTypes.Single):
                        type = "System.Single";
                        break;
                    case (DataTypes.String):
                        type = "System.String";
                        break;
                    default:
                        throw new InvalidEnumArgumentException();
                }

                dataTypeList.Add(new DataTypeVM
                {
                    Id = Guid.Empty,
                    Name = type
                });
            }

            return dataTypeList;
        }
    }
}