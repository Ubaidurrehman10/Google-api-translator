using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Google.Apis.Services;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoogleTranslator.Utility;
using GoogleTranslator.Model;
using GoogleTranslator.Services;

namespace GoogleTranslator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorController : ControllerBase
    {
        private readonly ITranslator _translator;
        public TranslatorController(ITranslator translator)
        {
            _translator = translator;
        }
        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            return Ok("running");
        }
        [HttpGet]
        [Route("Translate")]
        public async Task<IActionResult> Translate(TranslatorModel model)
        {
            var result = await _translator.TranslateText(model.text, model.language);
            return Ok(result);
        }
        [HttpGet]
        [Route("TranslateHtml")]
        public ActionResult TranslateHtml(TranslatorHtmlModel model)
        {
            var translatedText = _translator.TranslateHtml(model.html, model.language);
            return Ok(translatedText);
        }
    }
}
