using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiplicationTable.Models
{
    public class MatrixModel
    {
       
        public MatrixModel(int matrixSize, MatrixBase matrixBase )
        {
            matrix_size = matrixSize == null ? 10 : matrixSize;
            matrix_base = matrixBase == null ? MatrixBase.BaseDecimal : matrixBase;
        }
        public int matrix_size { get; set; }
        public string[,] matrixModelItems { get;set; }

        public MatrixBase matrix_base { get; set; }

       
    }

 public enum MatrixBase
        {
            BaseDecimal ,
            BaseBinary ,
            BaseHex 
        }
}