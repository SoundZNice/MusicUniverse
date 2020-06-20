import Home from './Home'
import Artists from './Artists'
import Error from './Error'

export const routes = {};

(function(ctx){

    const pages = [{
            route: '/',
            component: Home,
            name: Home.name,
            nav: true
        },{
            route: '/artists',
            component: Artists,
            name: Artists.name,
            nav: true
        },{
            route: '/500',
            component: Error
        }
    ];

    ctx.get = () => pages

})(routes)