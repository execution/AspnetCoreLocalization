

var numberFormatterFn = function( properties, pluralGenerator ) {
	return function numberFormatter( value ) {
		validateParameterPresence( value, "value" );
		validateParameterTypeNumber( value, "value" );

		return numberFormat( value, properties, pluralGenerator );
	};
};

