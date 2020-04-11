using System;
using System.Collections.Generic;
using System.Text;

namespace TestRabbit
{
    public class MainProccess
    {

        private readonly IValidate _validate;
        private readonly IConvert _convert;
        private readonly IPublish _publish;
        private readonly IProcess _process;

        public MainProccess(IConvert convert,IPublish publish, IValidate validate, IProcess process)
        {
            _validate = validate;
            _convert = convert;
            _publish = publish;
            _process = process;
        }


        public void Run(string message)
        {
            if (_validate.Run(message))
            {
                _process.Run(message);
                //string convertData = _convert.Run(message);
                //_publish.Run(convertData);
            }              

        }


    }
}
