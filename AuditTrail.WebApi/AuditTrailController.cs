using System;
using System.Collections.Generic;
using System.Web.Http;
using Affecto.AuditTrail.Interfaces;
using Affecto.AuditTrail.WebApi.Mapping;
using Affecto.AuditTrail.WebApi.Model;
using Affecto.Mapping;

namespace Affecto.AuditTrail.WebApi
{
    public class AuditTrailController : ApiController
    {
        private readonly IAuditTrailService auditTrailService;
        private readonly MapperFactory mapperFactory;

        public AuditTrailController(IAuditTrailService auditTrailService)
        {
            this.auditTrailService = auditTrailService;
            mapperFactory = new MapperFactory();
        }

        /// <summary>
        /// Get audit trail entries.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpGet]
        [Route("v1/audittrail/entries")]
        public IHttpActionResult GetAuditTrailEntries()
        {
            ICollection<AuditTrailEntry> entries = mapperFactory.CreateAuditTrailEntryMapper().Map(auditTrailService.GetEntries());

            return Ok(entries);
        }

        [HttpGet]
        [Route("v1/audittrail/entries")]
        public IHttpActionResult GetAuditTrailEntries([FromUri(Name = "tf")] string timestampFilter, [FromUri(Name = "smf")] string summaryFilter, [FromUri(Name = "snf")] string subjectNameFilter, [FromUri(Name = "unf")] string userNameFilter)
        {
            ICollection<AuditTrailEntry> entries = mapperFactory.CreateAuditTrailEntryMapper().Map(auditTrailService.GetEntries());

            return Ok(entries);
        }

        [HttpPost]
        [Route("v1/audittrail/entries")]
        public IHttpActionResult GetAuditTrailEntries([FromBody]AuditTrailFilter tf)
        {
            var filter = mapperFactory.CreateAuditTrailFilterMapper().Map(tf);

            AuditTrailResult result = mapperFactory.CreateAuditTrailResultMapper().Map(auditTrailService.GetEntries(filter));

            return Ok(result);
        }
    }
}