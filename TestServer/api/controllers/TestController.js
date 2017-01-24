module.exports = {
    get: function(req, res) {
        var success = (req.param('foo') === 'bar');
        res.json({method: 'get', success: success});
    },
    post: function(req, res) {
        var success = (req.param('foo') === 'bar');
        res.json({method: 'post', success: success});
    },
    put: function(req, res) {
        var success = (req.param('foo') === 'bar');
        res.json({method: 'put', success: success});
    },
    delete: function(req, res) {
        var success = (req.param('foo') === 'bar');
        res.json({method: 'delete', success: success});
    },        
    goodFormat: function(req, res) {
        res.json({success: true});        
    },  
    badFormat: function(req, res) {
        res.ok("Not JSON");
    },
    unauthorized: function(req, res) {
        res.forbidden();
    },
    headersLocal: function(req, res) {
        res.json({fooBarHeader: req.headers['x-foo-bar-local'], success: true});
    },
    headersGlobal: function(req, res) {
        res.json({fooBarHeader: req.headers['x-foo-bar-global'], success: true});
    },
    headersOverride: function(req, res) {
        res.json({overrideHeader: req.headers['x-foo-bar-override'], success: true});
    },
};

