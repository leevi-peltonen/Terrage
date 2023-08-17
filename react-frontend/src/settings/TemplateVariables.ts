/**
 * Theme
 * Accepted values: 'dark', 'light'
 * 
 * Maybe add this to UI for user to change?
 */

export const Theme = 'dark'

/**
 * Header text: string
 */
export const HeaderText = "TERRAGE"

/**
 * Header Menu Options
 * name: string
 * ...
 */
export const HeaderMenuOptions = (
    [
        {
            name: "User Profile",
            path: "/profile"
        },
        {
            name: "Settings",
            path: "/settings"
        },

    ]
)

export const SidebarMenuOptions = (
    [
        {
            name: "Home",
            path: "/"
        },
        {
            name: "Village",
            path: "/village"
        },
        {
            name: "World Map",
            path: "/map"
        },
        {
            name: "Quests",
            path: "/quests"
        },
        {
            name: "Friends / Clan",
            path: "/social"
        }
    ]
)