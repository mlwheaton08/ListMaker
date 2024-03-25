export const navDropdowns = {
    mobileNav: {
        id:"mobile-nav",
        className: "navSection navMain mobile",
        clickOrHover: "hover",
        navItems: [
            {text: "Items", navigateTo: "/items"},
            {text: "Recipes", navigateTo: "/recipes"},
            {text: "Grocery Lists", navigateTo: "/groceryLists"}
        ],
        icon: {
            type: "bars",
            id: "mobile-nav-icon",
            className: "relative h-1/2 top-1/2 -translate-y-1/2 hover:cursor-pointer transition-all duration-300",
            classNameActive: "fill-clr-primary",
            classNameInactive: "fill-clr-foreground"
        },
        spacer: {
            className: "h-1/2"
        },
        dropdown: {
            id: "mobile-nav-dropdown",
            children: {
                className: "dropdownNavItem hover:text-clr-primary"
            }
        }
    },
    accountNav: {
        id:"account-nav",
        className: "navSection",
        clickOrHover: "hover",
        navItems: [
            {text: "My Lists", navigateTo: "/ml"},
            {text: "My Recipes", navigateTo: "/mr"},
            {text: "My Items", navigateTo: "/mi"},
            {text: "Settings", navigateTo: "/s"},
            {text: "Sign Out", navigateTo: "/so"}
        ],
        icon: {
            type: "profile",
            id: "account-nav-icon",
            className: "relative h-3/5 p-px top-1/2 -translate-y-1/2 rounded-full border-2 fill-clr-accent hover:cursor-pointer transition-all duration-300",
            classNameActive: "border-clr-accent",
            classNameInactive: "border-clr-foreground"
        },
        spacer: {
            className: "h-2/5"
        },
        dropdown: {
            id: "account-nav-dropdown",
            children: {
                className: "dropdownNavItem hover:text-clr-accent"
            }
        }
    }
}