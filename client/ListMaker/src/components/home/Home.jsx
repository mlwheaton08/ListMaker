import "./Home.css"

export function Home() {

    return (
        <div>
            <img
                id="home-splash-img"
                src="../../../public/homeSplash.jpg"
                alt="List Maker logo"
            />
            <div id="home-splash-overlay"></div>

            <div id="home-container">
                <h1 className="text-4xl">Make shopping easier.</h1>
                <button className="bg-clr-primary text-clr-background rounded px-3 py-1 hover:text-clr-background-2 hover:bg-clr-secondary transition-all duration-200">
                    Start a new grocery list
                </button>
            </div>
        </div>
    )
}