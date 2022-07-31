using System;
using System.Collections.Generic;
using System.Text;

namespace UTools.Application.Dtos
{
    public class ResponseDTO
    {
        public bool HasError { get; set; }

        private string message;
        public string Message 
        { 
            get => string.IsNullOrEmpty(message) ? (HasError ? "Falha na operação" : "Operação feita com sucesso") : message; 
            set => message = value; 
        }
    }

    public class ResponseDTO<T>
    {
        public bool HasError { get; set; }
        private string message;
        public string Message
        {
            get => string.IsNullOrEmpty(message) ? (HasError ? "Falha na operação" : "Operação feita com sucesso") : message;
            set => message = value;
        }
        public T Result { get; set; }
    }
}
