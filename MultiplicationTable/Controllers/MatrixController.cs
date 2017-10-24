using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiplicationTable.Models;

namespace MultiplicationTable.Controllers
{
    public class MatrixController : Controller
    {
        public ActionResult Index()
        {
            var matrixModel = new MatrixModel(10, MatrixBase.BaseDecimal);
            //matrixModel.matrix_size = 10;
            matrixModel.matrixModelItems = new string[matrixModel.matrix_size +1, matrixModel.matrix_size +1];
            matrixModel.matrixModelItems[0, 0] = "0";
            int matrixStep = 0;
            
                for(int j=1;j<= matrixModel.matrix_size; j++)
                {
                    matrixStep += 1;
                    matrixModel.matrixModelItems[0, j] = matrixStep.ToString();
                    matrixModel.matrixModelItems[j, 0] = matrixStep.ToString();
                }
           

            for (int i = 1; i <= matrixModel.matrix_size; i++)
            {
                for(int j = 1; j<= matrixModel.matrix_size; j++)
                {
                    matrixModel.matrixModelItems[i, j] = (i * j).ToString();

                }
            }

           

                return View(matrixModel);
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            MatrixBase selectedVal = (MatrixBase)Enum.Parse(typeof(MatrixBase), frm["matrix_base"]);
            var matrixModel = new MatrixModel(Convert.ToInt32(frm["matrix_size"]), (MatrixBase)selectedVal);
            //matrixModel.matrix_size = 10;
            matrixModel.matrixModelItems = new string[matrixModel.matrix_size + 1, matrixModel.matrix_size + 1];
            matrixModel.matrixModelItems[0, 0] = "0";
            int matrixStep = 0;

            for (int j = 1; j <= matrixModel.matrix_size; j++)
            {
                matrixStep += 1;
                matrixModel.matrixModelItems[0, j] = matrixStep.ToString();
                matrixModel.matrixModelItems[j, 0] = matrixStep.ToString();
            }


            for (int i = 1; i <= matrixModel.matrix_size; i++)
            {
                for (int j = 1; j <= matrixModel.matrix_size; j++)
                {
                    matrixModel.matrixModelItems[i, j] = (i * j).ToString();
                    if(matrixModel.matrix_base == MatrixBase.BaseHex)
                    {
                        matrixModel.matrixModelItems[i, j] = Convert.ToInt32(matrixModel.matrixModelItems[i, j]).ToString("X2");
                    }
                    else if(matrixModel.matrix_base == MatrixBase.BaseBinary)
                    {
                        matrixModel.matrixModelItems[i, j] = Convert.ToString(Convert.ToInt32(matrixModel.matrixModelItems[i, j]), 2);
                    }
                }
            }



            return View(matrixModel);
        }
       
    }
}