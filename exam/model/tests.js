const fs = require('fs');
const path = require('path');

// Add your solutions here

function countOdd(ns)
{
    return ns.filter(n => n % 2 !== 0).length;
}



// Below is the test code, don't touch

function asserteq(expected, actual)
{
    if ( expected !== actual )
    {
        throw new Error(`Expected ${expected}, received ${actual}`);
    }
}

function showObject(object)
{
    return "{" + Object.entries(object).map( ([key, value]) => `${key}: ${value}` ).join(", ") + "}";
}

function showArray(xs)
{
    return "[" + xs.join(", ") + "]";
}

class Tests
{
    read()
    {
        return this.data.shift();
    }

    readInt()
    {
        return parseInt(this.read());
    }

    readBool()
    {
        return this.read() === 'true';
    }

    readStrings()
    {
        const n = this.readInt();
        const result = [];

        for ( let i = 0; i !== n; ++i )
        {
            result.push( this.read() );
        }

        return result;
    }

    runTests()
    {
        console.log(`Running tests for ${this.description}`);

        const absolutePath = path.join(__dirname, this.filename);
        this.data = fs.readFileSync(absolutePath, 'utf8').split("\n").filter( x => !x.startsWith('#') ).map( x => x.trimRight() );
        let line = this.read();

        while ( line === 'testcase' )
        {
            this.performTest();
            line = this.read();
        }
    }
}

class CountOddTests extends Tests
{
    constructor()
    {
        super();
        this.filename = 'count-odd.txt';
        this.description = 'countOdd';
    }

    performTest()
    {
        const ns = this.readStrings().map(i => parseInt(i));
        const expected = this.readInt();

        try
        {
            asserteq(expected, countOdd(ns));
            console.log('PASS');
        }
        catch ( e )
        {
            console.log('FAIL');
            console.log(`ns: ${showArray(ns)}`)
            console.log(e.message);
        }
    }
}


const tests = [ new CountOddTests() ];

for ( const test of tests )
{
    test.runTests();
}
