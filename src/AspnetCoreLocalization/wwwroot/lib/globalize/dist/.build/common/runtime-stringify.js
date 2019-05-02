

var runtimeStringify = function( args ) {
	return JSON.stringify( args, function( key, value ) {
		if ( value && value.runtimeKey ) {
			return value.runtimeKey;
		}
		return value;
	} );
};

