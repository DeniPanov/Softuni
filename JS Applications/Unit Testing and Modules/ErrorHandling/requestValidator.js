function validate(request) {
    let method = request.method;
    let uri = request.uri;
    let version = request.version;
    let message = request.message;

    const validMethods = ['GET', 'POST', 'CONNECT', 'DELETE'];

    if (!validMethods.includes(method) || !request.method) {
        throw Error('Invalid request header: Invalid Method');
    }

    let uriRegex = /^[\w.]+$/;
    if (!request.uri || !uri.match(uriRegex)) {
        throw Error('Invalid request header: Invalid URI');
    }

    const validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    if (!request.version || !validVersions.includes(version)) {
        throw Error('Invalid request header: Invalid Version');
    }

    let messageRegex = /^[^<>\\&'"]*$/;

    if (message === undefined || !message.match(messageRegex)) {
        throw Error('Invalid request header: Invalid Message');
    }

    return request;
}

console.log(validate({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}
));