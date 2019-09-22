# ThoughtWorks.MerchantsGuide.LanguageServices
identifiers, keywords, literals, operators, punctuators, and other separators

## Grammer

### Lexicon

#### Character Set
> ROMAN_SET := [IVXLCDM]
> WORD_SET := [abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ]
> NUMBER_SET := [01234567890]
> SEPARATOR_SET	: [?.,;\n]

#### Units
> CURRENCY_UNIT := Credits

#### Operators
> QUERY_OPERATOR := how (much|many) 	
> ASSIGNMENT_OPERATOR := is
> QUERTION_OPERATOR := ?

#### Literals
> WORD_LITERAL := [WORD_SET]+
> NUMBER_LITERAL := [NUMBER_SET]+.*[NUMBER_SET]*
> CURRENCY_LITERAL := [NUMBER_SET]+.*[NUMBER_SET]* CURRENCY_UNIT 
> ROMAN_LITERAL := [ROMAN_SET]+
> ROMAN_PREPROCESS_LITERAL := [ROMAN_PREPROCESS_SET]+

#### Identifier									 
> COMMODITY_IDENTIFIER := WORD_LITERAL } ex: Silver,Gold,Iron

### Clause

#### Literal Preprocessing Clause (glob is I)
> ROMAN_PREPROCESS_LITERAL_PREPROCESS := ROMAN_PREPROCESS_SET ASSIGNMENT_OPERATOR ROMAN_SET

#### Identifier Hoisting Clause (glob glob Silver is 34 Credits)
> COMMODITY_IDENTIFIER_HOIST := ROMAN_PREPROCESS_LITERAL COMMODITY_IDENTIFIER ASSIGNMENT_OPERATOR CURRENCY_LITERAL

#### Query Clause (how much is pish tegj glob glob ?, how many Credits is glob prok Silver ?)
> NUMERIC_SYMBOL_QUERY := QUERY_OPERATOR ASSIGNMENT_OPERATOR ROMAN_PREPROCESS_LITERAL QUERTION_OPERATOR
> CURRENCY_UNIT_QUERY := QUERY_OPERATOR CURRENCY_UNIT ASSIGNMENT_OPERATOR ROMAN_PREPROCESS_LITERAL COMMODITY_IDENTIFIER QUERTION_OPERATOR

#### Breakdown:
|Example|Rule|
|---|---|
|glob is I | ROMAN_LITERAL_PREPROCESS |
|prok is V | ROMAN_LITERAL_PREPROCESS |
|pish is X | ROMAN_LITERAL_PREPROCESS |
|tegj is L | ROMAN_LITERAL_PREPROCESS |
|glob glob Silver is 34 Credits | COMMODITY_IDENTIFIER_HOIST |
|glob prok Gold is 57800 Credits | COMMODITY_IDENTIFIER_HOIST |
|pish pish Iron is 3910 Credits | COMMODITY_IDENTIFIER_HOIST |
|how much is pish tegj glob glob ? | NUMERIC_SYMBOL_QUERY |
|how many Credits is glob prok Silver ? | CURRENCY_UNIT_QUERY |
|how many Credits is glob prok Gold ? | CURRENCY_UNIT_QUERY |
|how many Credits is glob prok Iron ? | CURRENCY_UNIT_QUERY |
