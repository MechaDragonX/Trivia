import * as express from 'express';
import * as exphbs from 'express-handlebars';

const config = require('../../config.json');
const app = express();

app.engine('.hbs', exphbs({
    extname: '.hbs'
}));
app.set('view engine', 'hbs');
app.use('/client', express.static(__dirname.slice(0, -6) + 'compiled'));


app.get('/', (req, res) => {
    return res.render('index', { title: 'NodeDex' });
});

app.listen(config.port, () => {
    console.log(`Running on ${ process.env.NODE_ENV === 'production' ? 'production' : 'debug' }, listening on port ${ config.port }`);
});
