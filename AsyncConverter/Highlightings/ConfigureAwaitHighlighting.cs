﻿using AsyncConverter.Highlightings;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

[assembly: RegisterConfigurableSeverity(ConfigureAwaitHighlighting.SeverityId, null, AsyncConverterGroupSettings.Id, "Await not configured", "If await not configured it may couse deadlock", Severity.WARNING)]

namespace AsyncConverter.Highlightings
{
    [ConfigurableSeverityHighlighting(SeverityId, CSharpLanguage.Name)]
    public class ConfigureAwaitHighlighting : IHighlighting
    {
        public IAwaitExpression AwaitExpression { get; }
        public const string SeverityId = "AsyncConverter.ConfigureAwaitHighlighting";

        public ConfigureAwaitHighlighting(IAwaitExpression awaitExpression)
        {
            AwaitExpression = awaitExpression;
        }

        public bool IsValid()
        {
            return AwaitExpression.IsValid();
        }

        public DocumentRange CalculateRange()
        {
            return AwaitExpression.GetDocumentRange();
        }

        public string ToolTip => "If await not configured it may couse deadlock, if this code will be call synchronously";
        public string ErrorStripeToolTip => "Await not configured";
    }
}