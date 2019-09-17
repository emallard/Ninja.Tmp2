(function ($) {

  var app = $.sammy('#main', function () {
    this.use('Template');

    this.addPage = function (pageUrl, pageType, pageTemplatePath) {
      console.log('addPage ' + pageUrl);
      this.get('#' + pageUrl, function (context) {
        context.app.swap('');
        context.render(pageTemplatePath, {}).appendTo(context.$element()).then(function () {
          var page = new pageType();
          page.onInit();
        })
      });
    }
    addRoutes(this);

  });

  $(function () {
    app.run('#/');
  });

})(jQuery);
